using Ocelot.DependencyInjection;
using TiendaServicios.Api.Gateway.MessageHandler;

namespace TiendaServicios.Api.Gateway.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOcelotConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOcelot(configuration).AddDelegatingHandler<LibroHandler>();
            return services;
        }
    }
}
