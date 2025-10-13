using Microsoft.Extensions.Logging;
using System.Text.Json;
using TiendaServicios.Api.CarritoCompra.Application.Common.Interfaces.Infrastructure;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.CarritoCompra.Application.DTOs.External;
using TiendaServicios.CarritoCompra.Infrastructure.RemoteServices.Libros.Models;

namespace TiendaServicios.CarritoCompra.Infrastructure.RemoteServices.Libros
{
    public class LibrosService : ILibrosService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<LibrosService> _logger;

        public LibrosService(IHttpClientFactory httpClientFactory, ILogger<LibrosService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        async Task<(bool resultado, LibroDto Libro, string ErrorMessage)> ILibrosService.GetLibro(Guid LibroId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Libros");
                var response = await client.GetAsync($"api/LibroMaterial/{LibroId}");

                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    var resultado = JsonSerializer.Deserialize<BaseResponse<LibroRemote>>(contenido, options);
                    var libroDto = MapToDto(resultado);

                    return (true, libroDto, null)!;
                }

                return (false, null, response.ReasonPhrase)!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message)!;
            }
        }

        private LibroDto? MapToDto(BaseResponse<LibroRemote>? remote)
        {
            if (remote == null) return null;

            return new LibroDto
            {
                LibreriaMaterialId = remote.Data.LibreriaMaterialId,
                Titulo = remote.Data.Titulo,
                FechaPublicacion = remote.Data.FechaPublicacion,
                AutorLibroId = remote.Data.AutorLibroId
            };
        }
    }
}
