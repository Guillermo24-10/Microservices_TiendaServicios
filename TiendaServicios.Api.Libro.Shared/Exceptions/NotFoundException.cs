namespace TiendaServicios.Autor.Application.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base("Entidad", $"Entidad \"{name}\"id: ({key}) no encontrado.")
        {
        }
    }
}
