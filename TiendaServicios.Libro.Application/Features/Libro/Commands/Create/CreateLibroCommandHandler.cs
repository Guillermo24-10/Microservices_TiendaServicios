using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Libro.Application.Features.Libro.Commands.Create
{
    public class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLibroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
        {
            var libro = new LibreriaMaterial()
            {
                Titulo = request.Titulo,
                FechaPublicacion = request.FechaPublicacion,
                AutorLibroId = request.AutorLibro
            };

            var result = await _unitOfWork.Libros.AddLibroAsync(libro, cancellationToken);
            if (result)
                return Result.Success();

            return Result.Failure(GlobalMessage.MESSAGE_FAILED);
        }
    }
}
