using System.Net;
using Ganjeh.Application.Util;
using Ganjeh.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        Error err = new Error($"Code: {context.Response.StatusCode}, Err: {contextFeature.Error.Message}");
                        TypedResult<Error> errorBody = new TypedResult<Error>(false, "Internal Server Error.", err);

                        await context.Response.WriteAsync(errorBody.ToJsonString());
                    }
                });
            });
        }
    }
}