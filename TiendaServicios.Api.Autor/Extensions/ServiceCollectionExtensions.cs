using TiendaServicios.Api.Autor.Extensions.GlobalException;

namespace TiendaServicios.Api.Autor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}
