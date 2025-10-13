using TiendaServicios.CarritoCompra.Application.DTOs.External;

namespace TiendaServicios.Api.CarritoCompra.Application.Common.Interfaces.Infrastructure
{
    public interface ILibrosService
    {
        Task<(bool resultado, LibroDto Libro, string ErrorMessage)> GetLibro(Guid LibroId);
    }
}
