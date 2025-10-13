using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Autor.Application.Features.Autores.Commands.Create;
using TiendaServicios.Autor.Application.Features.Autores.Queries.GetAll;
using TiendaServicios.Autor.Application.Features.Autores.Queries.GetById;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Crear([FromBody] CreateAutorCommand data)
        {
            try
            {
                var response = await _mediator.Send(data);

                return response;
            }
            catch (ValidationException ex)
            {
                var errores = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });

                return BadRequest(new { Errors = errores });
            }
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<AutorDto>>>> Get()
        {
            var response = await _mediator.Send(new GetAllAutoresQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<AutorDto>>> GetById(string id)
        {
            var response = await _mediator.Send(new GetAutorByIdQuery { AutorGuid = id });
            return response;
        }
    }
}
