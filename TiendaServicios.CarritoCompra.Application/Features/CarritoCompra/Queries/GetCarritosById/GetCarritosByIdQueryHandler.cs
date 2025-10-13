using MediatR;
using TiendaServicios.Api.CarritoCompra.Application.Common.Interfaces.Infrastructure;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.CarritoCompra.Application.Common.Interfaces.Persistence;
using TiendaServicios.CarritoCompra.Application.DTOs;

namespace TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Queries.GetCarritosById
{
    public class GetCarritosByIdQueryHandler : IRequestHandler<GetCarritosByIdQuery, BaseResponse<CarritoDto>>
    {
        private readonly ILibrosService _librosService;
        private readonly IUnitOfWork _unitOfWork;

        public GetCarritosByIdQueryHandler(ILibrosService librosService, IUnitOfWork unitOfWork)
        {
            _librosService = librosService;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<CarritoDto>> Handle(GetCarritosByIdQuery request, CancellationToken cancellationToken)
        {
            var carritoSesion = await _unitOfWork.CarritoCompraRepository.ObtenerCarritoSesionId(request.CarritoSesionId);
            var carritoSesionDetalle = await _unitOfWork.CarritoCompraRepository.ObtenerCarritoSesionDetalleId(request.CarritoSesionId);

            var listaCarritoDto = new List<CarritoDetalleDto>();

            foreach (var libro in carritoSesionDetalle)
            {
                var response = await _librosService.GetLibro(new Guid(libro.ProductoSeleccionado!));
                if (response.resultado)
                {
                    var objetoLibro = response.Libro;
                    var carritoDetalle = new CarritoDetalleDto
                    {
                        TituloLibro = objetoLibro.Titulo,
                        FechaPublicacion = objetoLibro.FechaPublicacion,
                        LibroId = objetoLibro.LibreriaMaterialId
                    };
                    listaCarritoDto.Add(carritoDetalle);
                }
            }

            if (carritoSesion != null)
            {
                var carritoSesionDto = new CarritoDto
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProductos = listaCarritoDto
                };

                return new BaseResponse<CarritoDto>(true, GlobalMessage.MESSAGE_QUERY, carritoSesionDto);
            }

            return new BaseResponse<CarritoDto>(true, GlobalMessage.MESSAGE_QUERY_EMPTY, null!);

        }
    }
}
