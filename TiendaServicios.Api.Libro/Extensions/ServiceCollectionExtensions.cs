using TiendaServicios.Api.Libro.Extensions.GlobalException;

namespace TiendaServicios.Api.Libro.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesApi(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}
