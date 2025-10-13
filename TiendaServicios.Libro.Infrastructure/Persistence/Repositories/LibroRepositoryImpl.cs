using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Libro.Infrastructure.Persistence.Repositories
{
    public class LibroRepositoryImpl : ILibroRepository
    {
        private readonly ContextoLibreria _contexto;

        public LibroRepositoryImpl(ContextoLibreria contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> AddLibroAsync(LibreriaMaterial libro, CancellationToken cancellationToken)
        {
            var libroEntity = new LibreriaMaterial
            {
                Titulo = libro.Titulo,
                FechaPublicacion = libro.FechaPublicacion,
                AutorLibroId = libro.AutorLibroId
            };
            await _contexto.AddAsync(libroEntity, cancellationToken);
            var resultado = await _contexto.SaveChangesAsync(cancellationToken);

            return resultado > 0;
        }

        public async Task<List<LibreriaMaterial>> GetAllLibreriaMaterialAsync()
        {
            var libros = await _contexto.LibreriaMaterial.ToListAsync();
            return libros;
        }

        public async Task<LibreriaMaterial> GetLibreriaMaterialByIdAsync(Guid? id)
        {
            var libro = await _contexto.LibreriaMaterial.Where(x => x.LibreriaMaterialId == id).FirstOrDefaultAsync();
            return libro!;
        }
    }
}
