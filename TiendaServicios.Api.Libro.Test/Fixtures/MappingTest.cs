using AutoMapper;
using TiendaServicios.Libro.Application.DTOs;
using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Api.Libro.Test.Fixtures
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<LibreriaMaterial,LibroMaterialDto>();

        }
    }
}
