using MediatR;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Shared.Common;

namespace TiendaServicios.Autor.Application.Features.Autores.Queries.GetAll
{
    public class GetAllAutoresQuery : IRequest<BaseResponse<List<AutorDto>>> { }
}
