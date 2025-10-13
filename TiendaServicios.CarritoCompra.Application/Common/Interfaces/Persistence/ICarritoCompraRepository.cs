using TiendaServicios.CarritoCompra.Domain.Entities;

namespace TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence
{
    public interface ICarritoCompraRepository
    {
        Task<int> AddCarritoCompra(CarritoSesion carritoSesion, CancellationToken cancellationToken);
        Task<int> AddCarritoSesionDetalle(CarritoSesionDetalle carritoSesionDetalle, CancellationToken cancellationToken);
        Task<int> AddCarritoSesionDetalles(List<CarritoSesionDetalle> detalles, CancellationToken cancellationToken);
        Task<CarritoSesion> ObtenerCarritoSesionId(int id);
        Task<List<CarritoSesionDetalle>> ObtenerCarritoSesionDetalleId(int id);
    }
}
