using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TiendaServicios.Api.Autor.Persistencia;
using TiendaServicios.Autor.Application.Common.Interfaces;
using TiendaServicios.Autor.Infrastructure.Persistence.Repositories;

namespace TiendaServicios.Autor.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Context Configuration
            services.AddDbContext<ContextoAutor>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ConexionDatabase"));
            });

            // Repositories
            //services.AddScoped<IAutorRepository, AutorRepositoryImpl>(); // ya no es necesario por el unit of work
            services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();


            return services;
        }
    }
}
