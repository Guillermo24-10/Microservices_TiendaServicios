using Moq;
using System.Diagnostics;
using TiendaServicios.Api.Libro.Test.Fixtures;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Application.Features.Libro.Queries.GetAll;

namespace TiendaServicios.Api.Libro.Test.Unit.Application.Queries
{
    public class GetAllLibrosQueryHandlerTest : IClassFixture<LibroTestFixture>
    {
        private readonly LibroTestFixture _fixture;

        public GetAllLibrosQueryHandlerTest(LibroTestFixture fixture)
        {
            _fixture = fixture;
        }

        private Mock<IUnitOfWork> CrearUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Libros.GetAllLibreriaMaterialAsync())
                .ReturnsAsync(_fixture.TestData);
            return mockUnitOfWork;
        }

        [Fact]
        public async Task Handle_CuandoExistenLibros_RetornaListaConLibros()
        {
            Debugger.Launch();
            // Arrange
            var mockUnitOfWork = CrearUnitOfWork();
            var handler = new GetAllLibrosQueryHandler(_fixture.Mapper, mockUnitOfWork.Object);
            var request = new GetAllLibrosQuery();

            // Act
            var resultado = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.Data.Any());
            Assert.Equal(30, resultado.Data.Count());
        }
    }
}
