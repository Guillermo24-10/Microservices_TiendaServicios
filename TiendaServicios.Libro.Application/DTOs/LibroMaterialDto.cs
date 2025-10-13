namespace TiendaServicios.Libro.Application.DTOs
{
    public class LibroMaterialDto
    {
        public Guid LibreriaMaterialId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
        public Guid AutorLibroId { get; set; }
    }
}
