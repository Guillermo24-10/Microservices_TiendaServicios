namespace TiendaServicios.Api.Libro.com
{
    public class BaseResponse<T>
    {
        public BaseResponse(bool success, string? message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public T Data {  get; set; }
    }
}
