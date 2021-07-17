using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using Alexandrovall.BitLyTestTask.Dto.RS.Common;
using Alexandrovall.BitLyTestTask.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Alexandrovall.BitLyTestTask.Filters
{
    public class CustomValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var exceptions = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(GetException)
                .Where(v => v != null)
                .ToList();

            var rootException = exceptions.Count > 1
                ? new AggregateException(exceptions)
                : exceptions.FirstOrDefault();

            string responseText = null;
                
            if (rootException != null)
            {
                var response = new ErrorResponse(rootException.Message, HttpStatusCode.BadRequest.ToString(), rootException);
                responseText = ToJson(response);
            }

            context.Result = new ContentResult {
                Content = responseText,
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }

        protected virtual string ToJson(ErrorResponse response)
        {
            return response.ToJson();
        }

        private static Exception GetException(ModelError modelError)
        {
            return string.IsNullOrEmpty(modelError.ErrorMessage)
                ? modelError.Exception
                : new ValidationException(modelError.ErrorMessage);
        }
    }
}