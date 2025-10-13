using FluentValidation.Results;

namespace TiendaServicios.Api.Shared.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(IEnumerable<ValidationFailure> failures) : base("Se han producido uno o más errores de validación.", "Consulte la propiedad de errores para obtener más detalles.")
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        public IDictionary<string, string[]> Errors { get; }
    }
}
