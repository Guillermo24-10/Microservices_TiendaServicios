using AutoMapper;
using TiendaServicios.Autor.Domain;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLibro, AutorDto>().ReverseMap();
        }
    }
}
