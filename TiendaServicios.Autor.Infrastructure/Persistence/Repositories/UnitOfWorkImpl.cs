using Microsoft.EntityFrameworkCore.Storage;
using TiendaServicios.Api.Autor.Persistencia;
using TiendaServicios.Autor.Application.Common.Interfaces;

namespace TiendaServicios.Autor.Infrastructure.Persistence.Repositories
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private readonly ContextoAutor _contextoAutor;
        private IDbContextTransaction? _transaction;


        private IAutorRepository? _autores;

        public UnitOfWorkImpl(ContextoAutor contextoAutor)
        {
            _contextoAutor = contextoAutor;
        }

        // Lazy loading - crea repositorios cuando se necesiten
        public IAutorRepository Autores => _autores ??= new AutorRepositoryImpl(_contextoAutor);

        // Métodos de transacción
        public async Task BeginTransactionAsync()
        {
            _transaction = await _contextoAutor.Database.BeginTransactionAsync();
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
            _contextoAutor.Dispose();
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
            return await _contextoAutor.SaveChangesAsync(cancellationToken);
        }
    }
}
