using AutoMapper;
using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Exceptions;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Application.DTOs;
using TiendaServicios.Libro.Domain;

namespace TiendaServicios.Libro.Application.Features.Libro.Queries.GetById
{
    public class GetLibroByIdQueryHandler : IRequestHandler<GetLibroByIdQuery, BaseResponse<LibroMaterialDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetLibroByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<LibroMaterialDto>> Handle(GetLibroByIdQuery request, CancellationToken cancellationToken)
        {
            var libro = await _unitOfWork.Libros.GetLibreriaMaterialByIdAsync(request.LibroId);
            if (libro == null)
            {
                return new BaseResponse<LibroMaterialDto>(false, $"{GlobalMessage.MESSAGE_QUERY_EMPTY}: {request.LibroId}", null!);
                throw new NotFoundException(nameof(libro), request.LibroId!);
            }

            var resut = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(libro);
            return new BaseResponse<LibroMaterialDto>(true, GlobalMessage.MESSAGE_QUERY, resut);
        }
    }
}
