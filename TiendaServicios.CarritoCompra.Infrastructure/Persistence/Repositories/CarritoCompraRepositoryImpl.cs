using Microsoft.EntityFrameworkCore;
using TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence;
using TiendaServicios.CarritoCompra.Domain.Entities;
using TiendaServicios.CarritoCompra.Infrastructure.Persistence.Data;

namespace TiendaServicios.CarritoCompra.Infrastructure.Persistence.Repositories
{
    public class CarritoCompraRepositoryImpl : ICarritoCompraRepository
    {
        private readonly CarritoContexto _context;

        public CarritoCompraRepositoryImpl(CarritoContexto context)
        {
            _context = context;
        }

        public async Task<int> AddCarritoCompra(CarritoSesion carritoSesion, CancellationToken cancellationToken)
        {
            var _carritoSesion = new CarritoSesion
            {
                FechaCreacion = carritoSesion.FechaCreacion
            };

            await _context.CarritoSesion.AddAsync(_carritoSesion, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _carritoSesion.CarritoSesionId;
        }

        public async Task<int> AddCarritoSesionDetalle(CarritoSesionDetalle carritoSesionDetalle, CancellationToken cancellationToken)
        {
            await _context.CarritoSesionDetalle.AddAsync(carritoSesionDetalle, cancellationToken);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> AddCarritoSesionDetalles(List<CarritoSesionDetalle> detalles, CancellationToken cancellationToken)
        {
            await _context.CarritoSesionDetalle.AddRangeAsync(detalles, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<List<CarritoSesionDetalle>> ObtenerCarritoSesionDetalleId(int id)
        {
            var carritoSesionDetalle = await _context.CarritoSesionDetalle.Where(x=>x.CarritoSesionId == id).ToListAsync();
            return carritoSesionDetalle;
        }

        public async Task<CarritoSesion> ObtenerCarritoSesionId(int id)
        {
            var carritoSesion = await _context.CarritoSesion.FirstOrDefaultAsync(x=>x.CarritoSesionId == id);
            return carritoSesion!;
        }
    }
}
