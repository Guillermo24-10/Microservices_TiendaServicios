using TiendaServicios.Autor.Domain;

namespace TiendaServicios.Autor.Application.Common.Interfaces
{
    public interface IAutorRepository
    {
        Task<IEnumerable<AutorLibro>> GetAllAutoresAsync();
        Task<AutorLibro> GetAutorByGuidAsync(string autorGuid);
        Task<bool> AddAutorAsync(AutorLibro autor, CancellationToken cancellationToken);
    }
}
