using System.Reflection;
using Alexandrovall.BitLyTestTask.BL.Mapping;
using Alexandrovall.BitLyTestTask.BL.MediatR.RequestHandlers;
using Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Extensions;
using Alexandrovall.BitLyTestTask.Dto.RS.Common;
using Alexandrovall.BitLyTestTask.Dto.Validators.RQ;
using Alexandrovall.BitLyTestTask.Filters;
using Alexandrovall.BitLyTestTask.Mapping.Profiles;
using Alexandrovall.BitLyTestTask.MediatR.Behaviors;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace Alexandrovall.BitLyTestTask
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add<CustomExceptionFilter>();
                    options.Filters.Add<CustomValidateModelStateFilter>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                }).AddFluentValidation(configuration =>
                {
                    configuration.ImplicitlyValidateChildProperties = true;
                    configuration.RegisterValidatorsFromAssemblyContaining<GetShortLinkListRequestValidator>();
                });

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Alexandrovall.BitLyTestTask", Version = "v1"});
                    c.IncludeXmlComments(Assembly.GetExecutingAssembly().Location.Replace("dll", "xml"));
                    c.IncludeXmlComments(typeof(Response).Assembly.Location.Replace("dll", "xml"));
                })
                .AddSwaggerGenNewtonsoftSupport();

            services.AddMongoDb(Configuration.GetConnectionString("MongoDb"), "bitlyTestTaskDb");
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(CommonProfile), typeof(MongoDbToMediatrProfile));
            services.AddMediatR(typeof(GetShortLinkListRequestHandler));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FillUserPipelineBehavior<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alexandrovall.BitLyTestTask v1"));
            }

            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}