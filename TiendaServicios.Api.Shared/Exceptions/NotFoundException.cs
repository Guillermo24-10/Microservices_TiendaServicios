namespace TiendaServicios.Api.Shared.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base("Entidad", $"Entidad \"{name}\"id: ({key}) no encontrado.")
        {
        }
    }
}
