using MediatR;
using TiendaServicios.Api.Shared.Common;

namespace TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Commands.Create
{
    public class CreateCarritoCompraCommand : IRequest<Result>
    {
        public DateTime FechaCreacionSesion { get; set; }
        public List<string> ProductoLista { get; set; } = new List<string>();
    }
}
