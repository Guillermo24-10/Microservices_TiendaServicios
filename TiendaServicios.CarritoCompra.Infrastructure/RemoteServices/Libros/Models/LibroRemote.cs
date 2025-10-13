namespace TiendaServicios.CarritoCompra.Infrastructure.RemoteServices.Libros.Models
{
    public class LibroRemote
    {
        public Guid LibreriaMaterialId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
        public Guid AutorLibroId { get; set; }
    }
}
