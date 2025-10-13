namespace TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICarritoCompraRepository CarritoCompraRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
