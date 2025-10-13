using Microsoft.Extensions.DependencyInjection;

namespace TiendaServicios.CarritoCompra.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // MediatR Configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            return services;
        }
    }
}
