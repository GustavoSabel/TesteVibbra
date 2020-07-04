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
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error != null)
                    {
                        if (exceptionHandlerPathFeature.Error is InvalidEntityException ex)
                        {
                            var errorMessage = new ErrorMessage() { Error = ex.Message };

                            context.Response.StatusCode = 400;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
                            return;
                        }
                        else
                        {
                            if (env.IsDevelopment())
                            {
                                context.Response.StatusCode = 500;
                                context.Response.ContentType = "text/html";
                                await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.ToString());
                                return;
                            }
                        }
                    }

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "Some error occurred";
                });
            });
        }
    }
}
