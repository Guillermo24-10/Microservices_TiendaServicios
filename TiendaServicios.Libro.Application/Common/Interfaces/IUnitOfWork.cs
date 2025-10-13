namespace TiendaServicios.Libro.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILibroRepository Libros { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
