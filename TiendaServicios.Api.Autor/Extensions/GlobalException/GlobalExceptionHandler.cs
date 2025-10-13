
using System.Net;
using TiendaServicios.Api.Shared.Exceptions;
using ApplicationException = TiendaServicios.Api.Shared.Exceptions.ApplicationException;

namespace TiendaServicios.Api.Autor.Extensions.GlobalException
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ApplicationException ex)
            {
                context.Response.ContentType = "application/json";

                object errors = null!;
                string title = "Excepciones de Aplicacion";

                if (ex is NotFoundException notFoundEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    title = "No Encontrado";
                }
                else if (ex is ValidationException validationEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    title = "Errores de Validacion";
                    errors = validationEx.Errors;
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                _logger.LogError(ex, $"Application exception: {title} - {ex.Message}");

                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message,
                    Title = title,
                    Errors = errors
                });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                _logger.LogError($"Exception Details: {message}");

                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error from the custom middleware.",
                    Detailed = ex.Message
                });
            }
        }
    }
}
