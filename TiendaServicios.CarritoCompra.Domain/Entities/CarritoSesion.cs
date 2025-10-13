namespace TiendaServicios.CarritoCompra.Domain.Entities
{
    public class CarritoSesion
    {
        public int CarritoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public ICollection<CarritoSesionDetalle>? ListaDetalle { get; set; }
    }
}
