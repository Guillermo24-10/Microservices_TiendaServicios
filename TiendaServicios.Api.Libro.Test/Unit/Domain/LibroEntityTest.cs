namespace TiendaServicios.Api.Libro.Test.Unit.Domain
{
    public class LibroEntityTest
    {
        public Guid LibreriaMaterialId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
        public Guid AutorLibroId { get; set; }
    }
}
