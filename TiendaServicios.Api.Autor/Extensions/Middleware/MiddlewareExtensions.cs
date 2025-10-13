using TiendaServicios.Api.Autor.Extensions.GlobalException;

namespace TiendaServicios.Api.Autor.Extensions.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
