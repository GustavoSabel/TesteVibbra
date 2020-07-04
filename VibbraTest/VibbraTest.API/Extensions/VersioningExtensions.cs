using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace VibbraTest.API.Extensions
{
    public static class VersioningExtensions
    {
        public static void AddVersioningVibbra(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.Conventions.Add(new VersionByNamespaceConvention());
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
