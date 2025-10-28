using MediatR;
using TiendaServicios.Api.Shared.Common;

namespace TiendaServicios.Autor.Application.Features.Autores.Commands.Create
{
    public class CreateAutorCommand : IRequest<Result>
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
