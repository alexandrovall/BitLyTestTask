using System;
using System.Threading;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Alexandrovall.BitLyTestTask.MediatR.Behaviors
{
    public class FillUserPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private const string UserIdCookieName = "UserId";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public FillUserPipelineBehavior(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return request switch
            {
                UserRequest userRequest => FillUser(userRequest, next),
                _ => next()
            };
        }

        private async Task<TResponse> FillUser(UserRequest userRequest, RequestHandlerDelegate<TResponse> next)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(UserIdCookieName, out var userId))
            {
                userRequest.UserId = userId;
                return await next();
            }

            userRequest.UserId = Guid.NewGuid().ToString("N");

            _httpContextAccessor.HttpContext.Response.Cookies.Append(UserIdCookieName, userRequest.UserId);

            return await next();
        }
    }
}