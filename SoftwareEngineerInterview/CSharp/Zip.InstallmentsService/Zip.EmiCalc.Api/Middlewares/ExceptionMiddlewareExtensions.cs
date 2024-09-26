using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Zip.EmiCalc.RequestResponseModels.ResponseModels;

namespace Zip.EmiCalc.Api.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureZipCoExceptionHandler(this IApplicationBuilder app, ILogger logger)
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
                        var errorDetail = new ErrorDetails()
                        {
                            Title = "Error From API",
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error occured."
                        };
                        await context.Response.WriteAsync(errorDetail.ToString());
                    }
                });
            });
        }

    }
}
