using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Persistencia;
using TiendaServicios.Autor.Application.Common.Interfaces;
using TiendaServicios.Autor.Domain;

namespace TiendaServicios.Autor.Infrastructure.Persistence.Repositories
{
    public class AutorRepositoryImpl : IAutorRepository
    {
        private readonly ContextoAutor _contexto;

        public AutorRepositoryImpl(ContextoAutor contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> AddAutorAsync(AutorLibro autor, CancellationToken cancellationToken)
        {
            if (autor == null)
            {
                throw new ArgumentNullException(nameof(autor));
            }

            await _contexto.Autor.AddAsync(autor, cancellationToken);
            var created = await _contexto.SaveChangesAsync(cancellationToken);
            return created > 0;
        }

        public async Task<IEnumerable<AutorLibro>> GetAllAutoresAsync()
        {
            var autores = await _contexto.Autor.ToListAsync();
            return autores;
        }

        public async Task<AutorLibro> GetAutorByGuidAsync(string autorGuid)
        {
            var autor = await _contexto.Autor.Where(x => x.AutorLibroGuid == autorGuid).FirstOrDefaultAsync();
            return autor!;
        }
    }
}
