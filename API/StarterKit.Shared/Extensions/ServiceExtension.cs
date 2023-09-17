using StarterKit.Domain.Interfaces.Services;
using StarterKit.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StarterKit.Shared.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationSharedServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IExternalDataService, ExternalDataService>();
            services.AddScoped<ITranslationService, TranslationService>();

            return services;
        }
    }
}
