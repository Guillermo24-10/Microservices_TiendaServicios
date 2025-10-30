using Ocelot.DependencyInjection;

namespace TiendaServicios.Api.Gateway.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOcelotConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOcelot(configuration);
            return services;
        }
    }
}
