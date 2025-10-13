using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Libro.Application.DTOs;

namespace TiendaServicios.Libro.Application.Features.Libro.Queries.GetById
{
    public class GetLibroByIdQuery : IRequest<BaseResponse<LibroMaterialDto>>
    {
        public Guid? LibroId { get; set; }
    }
}
