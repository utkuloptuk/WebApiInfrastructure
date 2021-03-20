using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Helper.ExceptionHandler
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionHandleMiddleware> logger;

        public ExceptionHandleMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandleMiddleware> logger)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
                logger.LogError($@"Someting went wrong: {ex}");
            }
        }
        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
