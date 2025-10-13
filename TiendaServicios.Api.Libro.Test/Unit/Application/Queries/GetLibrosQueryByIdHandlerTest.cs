using Moq;
using System.Diagnostics;
using TiendaServicios.Api.Libro.Test.Fixtures;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Application.Features.Libro.Queries.GetById;

namespace TiendaServicios.Api.Libro.Test.Unit.Application.Queries
{
    public class GetLibrosQueryByIdHandlerTest : IClassFixture<LibroTestFixture>
    {
        private readonly LibroTestFixture _fixture;

        public GetLibrosQueryByIdHandlerTest(LibroTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_seenviaId_retornaLibro()
        {
            Debugger.Launch();
            //Arrange
            var LibroId = Guid.Empty;
            var libroEsperado = _fixture.ObtenerDataPorId(LibroId);
            var mockUniOfWork = new Mock<IUnitOfWork>();
            mockUniOfWork.Setup(x => x.Libros.GetLibreriaMaterialByIdAsync(LibroId)).ReturnsAsync(libroEsperado);



            var handler = new GetLibroByIdQueryHandler(_fixture.Mapper, mockUniOfWork.Object);
            var request = new GetLibroByIdQuery { LibroId = LibroId };


            //Act
            var resultado = await handler.Handle(request, new CancellationToken());



            //Assert

            Assert.NotNull(resultado);
            Assert.True(resultado.Data.LibreriaMaterialId == Guid.Empty);
        }
    }
}
