namespace TiendaServicios.Autor.Domain
{
    public class AutorLibro
    {
        public int AutorLibroId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; } = new List<GradoAcademico>();
        public string AutorLibroGuid { get; set; } = string.Empty;
    }
}
