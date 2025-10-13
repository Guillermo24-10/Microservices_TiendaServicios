using MediatR;
using TiendaServicios.Api.CarritoCompra.Application.Common.Interfaces.Infrastructure;
using TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence;
using TiendaServicios.CarritoCompra.Application.DTOs;

namespace TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Commands.AddItemToCarrito
{
    internal class AddItemToCarritoCommandHandler : IRequestHandler<AddItemToCarritoCommand, CarritoDto>
    {
        private readonly ILibrosService _librosService;
        private readonly IUnitOfWork _unitOfWork;

        public AddItemToCarritoCommandHandler(ILibrosService librosService, IUnitOfWork unitOfWork)
        {
            _librosService = librosService;
            _unitOfWork = unitOfWork;
        }

        public Task<CarritoDto> Handle(AddItemToCarritoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
