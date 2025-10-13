using MediatR;
using TiendaServicios.Api.Shared.Common;

namespace TiendaServicios.Libro.Application.Features.Libro.Commands.Create
{
    public class CreateLibroCommand : IRequest<Result>
    {
        public string Titulo { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
        public Guid AutorLibro { get; set; } = Guid.Empty;
    }
}
