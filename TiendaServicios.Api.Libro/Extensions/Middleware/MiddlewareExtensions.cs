using TiendaServicios.Api.Libro.Extensions.GlobalException;

namespace TiendaServicios.Api.Libro.Extensions.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
