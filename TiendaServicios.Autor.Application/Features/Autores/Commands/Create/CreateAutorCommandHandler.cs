using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.Autor.Application.Common.Interfaces;
using TiendaServicios.Autor.Domain;

namespace TiendaServicios.Autor.Application.Features.Autores.Commands.Create
{
    public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            var autorLibro = new AutorLibro
            {
                Nombre = request.Nombre!,
                Apellido = request.Apellido!,
                FechaNacimiento = request.FechaNacimiento,
                AutorLibroGuid = Guid.NewGuid().ToString()
            };

            var response = await _unitOfWork.Autores.AddAutorAsync(autorLibro, cancellationToken);
            if (response)
                return Result.Success();

            return Result.Failure(GlobalMessage.MESSAGE_FAILED);
        }
    }
}
