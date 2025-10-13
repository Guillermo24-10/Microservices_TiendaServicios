using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Autor.Application.Behaviors;

namespace TiendaServicios.Autor.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // MediatR Configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            // AutoMapper Configuration
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // FluentValidation Configuration
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

            // Behavior Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


            return services;
        }
    }
}
