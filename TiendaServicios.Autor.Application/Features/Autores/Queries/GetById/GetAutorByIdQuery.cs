using MediatR;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Shared.Common;

namespace TiendaServicios.Autor.Application.Features.Autores.Queries.GetById
{
    public class GetAutorByIdQuery : IRequest<BaseResponse<AutorDto>>
    {
        public required string AutorGuid { get; set; }
    }
}
