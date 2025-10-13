using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaServicios.Api.CarritoCompra.Application.Common.Interfaces.Infrastructure;
using TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence;
using TiendaServicios.CarritoCompra.Infrastructure.Persistence.Data;
using TiendaServicios.CarritoCompra.Infrastructure.Persistence.Repositories;
using TiendaServicios.CarritoCompra.Infrastructure.RemoteServices.Libros;

namespace TiendaServicios.CarritoCompra.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILibrosService, LibrosService>();
            services.AddDbContext<CarritoContexto>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("ConexionDatabase"),
                    new MySqlServerVersion(new Version(8, 0, 21)));
            });

            services.AddHttpClient("Libros", config =>
            {
                config.BaseAddress = new Uri(configuration["Services:Libros"]!);
            });

            services.AddScoped<IUnitOfWork, UniOfWorkImpl>();

            return services;
        }
    }
}
