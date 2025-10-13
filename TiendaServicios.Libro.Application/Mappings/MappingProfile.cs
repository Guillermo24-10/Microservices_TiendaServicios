using AutoMapper;
using TiendaServicios.Libro.Application.DTOs;
using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Libro.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>().ReverseMap();
        }
    }
}
