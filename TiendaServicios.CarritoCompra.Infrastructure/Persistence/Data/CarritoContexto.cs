using Microsoft.EntityFrameworkCore;
using TiendaServicios.CarritoCompra.Domain.Entities;

namespace TiendaServicios.CarritoCompra.Infrastructure.Persistence.Data
{
    public class CarritoContexto : DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options) : base(options) { }

        public DbSet<CarritoSesion> CarritoSesion { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }
    }
}
