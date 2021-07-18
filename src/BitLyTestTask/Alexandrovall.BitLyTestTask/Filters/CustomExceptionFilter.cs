using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Alexandrovall.BitLyTestTask.Dto.RS.Common;
using Alexandrovall.BitLyTestTask.Exceptions;
using Alexandrovall.BitLyTestTask.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Alexandrovall.BitLyTestTask.Filters
{
    internal class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var statusCode = GetStatusCode(exception);

            var responseText = HideResponseText(statusCode)
                ? null
                : new ErrorResponse(exception.Message, statusCode.ToString(), exception).ToJson();

            context.Result = new ContentResult
            {
                Content = responseText,
                ContentType = "application/json",
                StatusCode = (int) statusCode,
            };

            context.ExceptionHandled = true;

            Log.Error(exception, "{RequestMethod} {RequestPath} {RequestId}");
        }

        private static bool HideResponseText(HttpStatusCode statusCode) =>
            statusCode >= HttpStatusCode.InternalServerError;

        private static HttpStatusCode GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ValidationException => HttpStatusCode.BadRequest,
                CollectionItemNotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}