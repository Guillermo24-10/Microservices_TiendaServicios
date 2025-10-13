using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.Test.Fixtures;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Application.Features.Libro.Commands.Create;
using TiendaServicios.Libro.Infrastructure.Persistence.Repositories;

namespace TiendaServicios.Api.Libro.Test.Integration.Infrastructure
{
    public class CreateLibroIntegrationTest
    {
        private readonly ContextoLibreria _contexto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLibroIntegrationTest()
        {
            // ✅ SOLO AQUÍ cambias a UseInMemoryDatabase
            // Tu código de Infrastructure NO cambia nada
            var options = new DbContextOptionsBuilder<ContextoLibreria>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // ✅ Usas tu ContextoLibreria REAL (el mismo de producción)
            _contexto = new ContextoLibreria(options);

            // ✅ Usas tu UnitOfWork REAL (el mismo de producción)
            _unitOfWork = new UnitOfWorkImpl(_contexto);

            // Mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task CreateLibro_ConHandlerReal_DeberiaGuardarEnMemoria()
        {
            Debugger.Launch();
            //Arrange
            var command = new CreateLibroCommand
            {
                Titulo = "LIBRO DE MICROSERVICE",
                AutorLibro = Guid.Empty,
                FechaPublicacion = DateTime.Now
            };

            var handler = new CreateLibroCommandHandler(_unitOfWork);

            // Act
            var resultado = await handler.Handle(command, new CancellationToken());


            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.Succeeded);

            var todosLosLibros = await _unitOfWork.Libros.GetAllLibreriaMaterialAsync();
            Assert.Single(todosLosLibros);
        }
    }
}
