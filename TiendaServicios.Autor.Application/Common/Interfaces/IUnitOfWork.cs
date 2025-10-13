namespace TiendaServicios.Autor.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAutorRepository Autores { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
