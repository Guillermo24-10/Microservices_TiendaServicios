using AutoMapper;
using MediatR;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.Libro.Application.Common.Interfaces;
using TiendaServicios.Libro.Application.DTOs;

namespace TiendaServicios.Libro.Application.Features.Libro.Queries.GetAll
{
    public class GetAllLibrosQueryHandler : IRequestHandler<GetAllLibrosQuery, BaseResponse<List<LibroMaterialDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLibrosQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<List<LibroMaterialDto>>> Handle(GetAllLibrosQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Libros.GetAllLibreriaMaterialAsync();

            if (response == null || !response.Any())
            {
                return new BaseResponse<List<LibroMaterialDto>>(false, GlobalMessage.MESSAGE_QUERY_EMPTY, null!);
            }

            var librosDto = _mapper.Map<List<LibroMaterialDto>>(response);

            return new BaseResponse<List<LibroMaterialDto>>(true, GlobalMessage.MESSAGE_QUERY, librosDto);
        }
    }
}
