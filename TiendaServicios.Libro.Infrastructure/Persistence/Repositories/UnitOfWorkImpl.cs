using Microsoft.EntityFrameworkCore.Storage;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Libro.Application.Common.Interfaces;

namespace TiendaServicios.Libro.Infrastructure.Persistence.Repositories
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private readonly ContextoLibreria _contextoLibreria;
        private IDbContextTransaction? _transaction;

        private ILibroRepository? _libros;

        public UnitOfWorkImpl(ContextoLibreria contextoLibreria)
        {
            _contextoLibreria = contextoLibreria;
        }

        // Lazy loading - crea repositorios cuando se necesiten
        public ILibroRepository Libros => _libros ??= new LibroRepositoryImpl(_contextoLibreria);

        // Metodos de transaccion
        public async Task BeginTransactionAsync()
        {
            _transaction = await _contextoLibreria.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _contextoLibreria.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _contextoLibreria.SaveChangesAsync(cancellationToken);
        }
    }
}
