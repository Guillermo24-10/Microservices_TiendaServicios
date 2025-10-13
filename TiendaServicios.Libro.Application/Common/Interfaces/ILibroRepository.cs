using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Libro.Application.Common.Interfaces
{
    public interface ILibroRepository
    {
        Task<bool> AddLibroAsync(LibreriaMaterial libro, CancellationToken cancellationToken);
        Task<List<LibreriaMaterial>> GetAllLibreriaMaterialAsync();
        Task<LibreriaMaterial> GetLibreriaMaterialByIdAsync(Guid? id);
    }
}
