using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using VibbraTest.API.Extensions;
using VibbraTest.Infra;

namespace VibbraTest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironmen)
        {
            Configuration = configuration;
            WebHostEnvironmen = webHostEnvironmen;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironmen { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt =>
                    opt.InvalidModelStateResponseFactory = actionContext => CustomModelValidationResponse(actionContext))
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance);

            services.AddMvc(opt =>
            {
                opt.UseGeneralRoutePrefix("api/v{version:apiVersion}");
            });

            services.AddVersioningVibbra();

            services.AddSwaggerVibbra();

            services.AddResponseCompression();

            services.AddDbContext<VibbraContext>(options =>
            {
                VibbraContext.Configurar(options, Configuration.GetConnectionString("Default"), WebHostEnvironmen.IsDevelopment());
            });

            services.AddRepositoriesAndServices();
        }

        private BadRequestObjectResult CustomModelValidationResponse(ActionContext actionContext)
        {
            var fieldValidations = actionContext.ModelState
                 .Where(modelError => modelError.Value.Errors.Count > 0)
                 .Select(x => new FieldValidation(x.Key, x.Value.Errors.FirstOrDefault().ErrorMessage))
                 .ToArray();

            var errorMessage = new ErrorMessage("Alguns campos estão inválidos", fieldValidations);

            return new BadRequestObjectResult(errorMessage);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseResponseCompression();

            app.UseExceptionHandlerVibbra(env);

            app.UseSwaggerVibbra(provider);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            MigrarBancoDados(app);
        }

        private static void MigrarBancoDados(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<VibbraContext>();
            context.Database.Migrate();
        }
    }
}
