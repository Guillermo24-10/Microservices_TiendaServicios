namespace TiendaServicios.Autor.Application.Common.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public static Result Success()
        {
            return new Result { Succeeded = true, Errors = Array.Empty<string>() };
        }
        public static Result Failure(params string[] errors)
        {
            return new Result { Succeeded = false, Errors = errors };
        }
    }
}
