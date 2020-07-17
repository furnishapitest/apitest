using EuroFurnish.ApplicationCore.Exceptions;
using EuroFurnish.ApplicationCore.Extensions;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Interfaces;
using EuroFurnish.ApplicationCore.Providers.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EuroFurnish.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionHandlerMiddleware(RequestDelegate request)
        {
            this.request = request;
        }

        public Task Invoke(HttpContext context) => this.InvokeAsync(context);

        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await request(context);
                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    await EventResponse(context, new UnauthorizedAccessException("Unauthorized Request!"));
                }
            }
            catch (Exception exception)
            {
                await EventResponse(context, exception);
            }
        }
        private async Task EventResponse(HttpContext context, Exception exception)
        {
            var httpStatusCode = ConfigurateExceptionTypes(exception);
            context.Response.StatusCode = httpStatusCode;
            context.Response.ContentType = "application/json";
            var errorMsg = new { ErrorMessage = exception.Message };
            var responseJson = errorMsg.ToJson();
            await context.Response.WriteAsync(responseJson);
        }

        private int ConfigurateExceptionTypes(Exception exception)
        {
            int httpStatusCode;

            // Exception type To Http Status configuration 
            switch (exception)
            {
                case var _ when exception is ValidationAdapterException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case var _ when exception is UnauthorizedAccessException:
                    httpStatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case var _ when exception is ArgumentNullException:
                    httpStatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return httpStatusCode;
        }
    }
}
