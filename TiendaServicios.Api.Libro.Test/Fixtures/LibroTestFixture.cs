using AutoMapper;
using GenFu;
using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Api.Libro.Test.Fixtures
{
    public class LibroTestFixture : IDisposable
    {
        public IMapper Mapper { get; }
        public List<LibreriaMaterial> TestData { get; }

        public LibroTestFixture()
        {
            Mapper = CrearMapper();
            TestData = ObtenerDataPrueba().ToList();
        }

        private IEnumerable<LibreriaMaterial> ObtenerDataPrueba()
        {
            //libreria Genfu
            GenFu.GenFu.Configure<LibreriaMaterial>()
                .Fill(x => x.Titulo).AsArticleTitle()
                .Fill(x => x.LibreriaMaterialId, () => Guid.NewGuid());

            var lista = GenFu.GenFu.ListOf<LibreriaMaterial>(30);
            lista[0].LibreriaMaterialId = Guid.Empty;
            return lista;
        }
        public LibreriaMaterial ObtenerDataPorId(Guid id)
        {
            return TestData.FirstOrDefault(x => x.LibreriaMaterialId == id)!;
        }
        private IMapper CrearMapper()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            return mapConfig.CreateMapper();
        }
        public void Dispose()
        {
        }
    }
}
