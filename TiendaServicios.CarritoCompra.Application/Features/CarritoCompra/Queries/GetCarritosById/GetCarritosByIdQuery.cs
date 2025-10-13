using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.CarritoCompra.Application.DTOs;

namespace TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Queries.GetCarritosById
{
    public class GetCarritosByIdQuery : IRequest<BaseResponse<CarritoDto>>
    {
        public int CarritoSesionId { get; set; }
    }
}
