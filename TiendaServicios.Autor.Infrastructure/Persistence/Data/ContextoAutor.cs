using Microsoft.EntityFrameworkCore;
using TiendaServicios.Autor.Domain;

namespace TiendaServicios.Api.Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options)
        {
        }

        public DbSet<AutorLibro> Autor { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }   
    }
}
