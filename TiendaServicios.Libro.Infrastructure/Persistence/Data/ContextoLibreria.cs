using Microsoft.EntityFrameworkCore;
using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
        {
        }
        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
