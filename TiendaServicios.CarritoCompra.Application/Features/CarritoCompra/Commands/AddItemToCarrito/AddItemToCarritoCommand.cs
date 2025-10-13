using MediatR;
using TiendaServicios.CarritoCompra.Application.DTOs;

namespace TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Commands.AddItemToCarrito
{
    public class AddItemToCarritoCommand : IRequest<CarritoDto>
    {
        public int CarritoSesionId { get; set; }
    }
}
