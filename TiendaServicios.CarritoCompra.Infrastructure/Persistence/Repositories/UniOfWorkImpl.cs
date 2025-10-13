using Microsoft.EntityFrameworkCore.Storage;
using TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence;
using TiendaServicios.CarritoCompra.Infrastructure.Persistence.Data;

namespace TiendaServicios.CarritoCompra.Infrastructure.Persistence.Repositories
{
    public class UniOfWorkImpl : IUnitOfWork
    {
        private readonly CarritoContexto _carritoContexto;
        private IDbContextTransaction? _dbTransaction;

        public UniOfWorkImpl(CarritoContexto carritoContexto)
        {
            _carritoContexto = carritoContexto;
        }

        public ICarritoCompraRepository? _carritoCompraRepository;
        public ICarritoCompraRepository CarritoCompraRepository => _carritoCompraRepository ??= new CarritoCompraRepositoryImpl(_carritoContexto);

        public async Task BeginTransactionAsync()
        {
            _dbTransaction = await _carritoContexto.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_dbTransaction != null)
            {
                await _dbTransaction.CommitAsync();
                await _dbTransaction.DisposeAsync();
                _dbTransaction = null!;
            }
        }

        public void Dispose()
        {
            _dbTransaction?.Dispose();
            _carritoContexto.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_dbTransaction != null)
            {
                await _dbTransaction.RollbackAsync();
                await _dbTransaction.DisposeAsync();
                _dbTransaction = null!;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _carritoContexto.SaveChangesAsync(cancellationToken);
        }
    }
}
