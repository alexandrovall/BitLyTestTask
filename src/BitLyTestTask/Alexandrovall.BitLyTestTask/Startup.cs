using System.Reflection;
using Alexandrovall.BitLyTestTask.Dto.RS.Common;
using Alexandrovall.BitLyTestTask.Dto.Validators.RQ;
using Alexandrovall.BitLyTestTask.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace Alexandrovall.BitLyTestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}