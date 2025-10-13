using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Libro.Application.DTOs;

namespace TiendaServicios.Libro.Application.Features.Libro.Queries.GetAll
{
    public class GetAllLibrosQuery : IRequest<BaseResponse<List<LibroMaterialDto>>>
    {
    }
}
