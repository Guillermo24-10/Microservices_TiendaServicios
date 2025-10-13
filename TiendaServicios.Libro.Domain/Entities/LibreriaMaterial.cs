namespace TiendaServicios.Libro.Domain
{
    public class LibreriaMaterial
    {
        public Guid LibreriaMaterialId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
        public Guid AutorLibroId { get; set; }
    }
}
