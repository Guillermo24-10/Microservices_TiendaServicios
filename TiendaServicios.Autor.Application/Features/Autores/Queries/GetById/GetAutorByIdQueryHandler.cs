using AutoMapper;
using MediatR;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Exceptions;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.Autor.Application.Common.Interfaces;
using TiendaServicios.Autor.Domain;

namespace TiendaServicios.Autor.Application.Features.Autores.Queries.GetById
{
    public class GetAutorByIdQueryHandler : IRequestHandler<GetAutorByIdQuery, BaseResponse<AutorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAutorByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<AutorDto>> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
        {
            var autor = await _unitOfWork.Autores.GetAutorByGuidAsync(request.AutorGuid);
            if (autor == null)
            {
                return new BaseResponse<AutorDto>(false, $"{GlobalMessage.MESSAGE_QUERY_EMPTY}: {request.AutorGuid}", null!);
                throw new NotFoundException(nameof(AutorLibro), request.AutorGuid);
            }
            var result = _mapper.Map<AutorLibro, AutorDto>(autor);

            return new BaseResponse<AutorDto>(true, GlobalMessage.MESSAGE_QUERY, result);
        }
    }
}
