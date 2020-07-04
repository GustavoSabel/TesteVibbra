using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VibbraTest.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerVibbra(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
        }

        public static void UseSwaggerVibbra(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }

        private class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            private readonly IApiVersionDescriptionProvider _provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
              _provider = provider;

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in _provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                      description.GroupName,
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = $"API de controle de Notas Fiscais para Freelancer {description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                        });
                }
            }
        }
    }
}
