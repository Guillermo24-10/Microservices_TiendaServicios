using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence;
using TiendaServicios.CarritoCompra.Domain.Entities;

namespace TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Commands.Create
{
    public class CreateCarritoCompraCommandHandler : IRequestHandler<CreateCarritoCompraCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarritoCompraCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateCarritoCompraCommand request, CancellationToken cancellationToken)
        {
            var carritoComp = new CarritoSesion { FechaCreacion = request.FechaCreacionSesion };

            var id = await _unitOfWork.CarritoCompraRepository.AddCarritoCompra(carritoComp, cancellationToken);

            var detalles = request.ProductoLista.Select(item => new CarritoSesionDetalle
            {
                FechaCreacion = DateTime.Now,
                CarritoSesionId = id,
                ProductoSeleccionado = item
            }).ToList();

            var result = await _unitOfWork.CarritoCompraRepository.AddCarritoSesionDetalles(detalles, cancellationToken);

            if (result > 0)
                return Result.Success();

            return Result.Failure(GlobalMessage.MESSAGE_FAILED);
        }
    }
}
