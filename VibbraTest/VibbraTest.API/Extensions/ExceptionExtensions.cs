using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using VibbraTest.Domain.Exceptions;

namespace VibbraTest.API.Extensions
{
    public static class ExceptionExtensions
    {
        public static void UseExceptionHandlerVibbra(this IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            app.UseExceptionHandler((System.Action<IApplicationBuilder>)(errorApp =>
            {
                errorApp.Run((RequestDelegate)(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error != null)
                    {
                        if (exceptionHandlerPathFeature.Error is BusinessException ex)
                        {
                            var errorMessage = new ErrorMessage((string)ex.Message);

                            context.Response.StatusCode = 400;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
                            return;
                        }

                        if (env.IsDevelopment())
                        {
                            context.Response.StatusCode = 500;
                            context.Response.ContentType = "text/html";
                            await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.ToString());
                            return;
                        }
                    }

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";
                    context.Response.ContentType = "An error occurred";
                }));
            }));
        }
    }
}
