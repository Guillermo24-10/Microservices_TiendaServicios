namespace TiendaServicios.Autor.Domain
{
    public class GradoAcademico
    {
        public int GradoAcademicoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CentroAcademico { get; set; } = string.Empty;
        public DateTime? FechaGrado { get; set; }
        public int AutorLibroId { get; set; }
        public AutorLibro? AutorLibro { get; set; }
        public string GradoAcademicoGuid { get; set; } = string.Empty;
    }

}
