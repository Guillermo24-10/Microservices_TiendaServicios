using AutoMapper;
using MediatR;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Api.Shared.Utils;
using TiendaServicios.Autor.Application.Common.Interfaces;
using TiendaServicios.Autor.Domain;

namespace TiendaServicios.Autor.Application.Features.Autores.Queries.GetAll
{
    public class GetAllAutoresQueryHandler : IRequestHandler<GetAllAutoresQuery, BaseResponse<List<AutorDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAutoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<AutorDto>>> Handle(GetAllAutoresQuery request, CancellationToken cancellationToken)
        {
            var autores = await _unitOfWork.Autores.GetAllAutoresAsync();
            if (autores == null || !autores.Any())
            {
                return new BaseResponse<List<AutorDto>>(false, GlobalMessage.MESSAGE_QUERY_EMPTY, null!);
            }

            var response = _mapper.Map<IEnumerable<AutorLibro>, IEnumerable<AutorDto>>(autores);

            return new BaseResponse<List<AutorDto>>(true, GlobalMessage.MESSAGE_QUERY, response.ToList());
        }
    }
}
