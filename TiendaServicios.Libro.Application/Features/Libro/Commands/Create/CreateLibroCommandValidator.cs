using FluentValidation;

namespace TiendaServicios.Libro.Application.Features.Libro.Commands.Create
{
    public class CreateLibroCommandValidator : AbstractValidator<CreateLibroCommand>
    {
        public CreateLibroCommandValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty();
            RuleFor(x => x.FechaPublicacion).NotEmpty();
            RuleFor(x => x.AutorLibro).NotEmpty();
        }
    }
}
