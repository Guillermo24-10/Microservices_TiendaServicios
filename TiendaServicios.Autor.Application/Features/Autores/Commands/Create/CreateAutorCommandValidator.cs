using FluentValidation;

namespace TiendaServicios.Autor.Application.Features.Autores.Commands.Create
{
    public class CreateAutorCommandValidator : AbstractValidator<CreateAutorCommand>
    {
        public CreateAutorCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().NotNull();
            RuleFor(x => x.Apellido).NotEmpty().NotNull();
        }
    }
}
