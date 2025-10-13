using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Infrastructure.Persistence.Repositories;

namespace TiendaServicios.Libro.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextoLibreria>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConexionDB"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();

            return services;
        }
    }
}
