using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.Libro.Application.DTOs;
using TiendaServicios.Libro.Application.Features.Libro.Commands.Create;
using TiendaServicios.Libro.Application.Features.Libro.Queries.GetAll;
using TiendaServicios.Libro.Application.Features.Libro.Queries.GetById;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Crear(CreateLibroCommand data)
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
        public async Task<ActionResult<BaseResponse<List<LibroMaterialDto>>>> GetLibros()
        {
            var response = await _mediator.Send(new GetAllLibrosQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<LibroMaterialDto>>> GetLibro(Guid id)
        {
            var response = await _mediator.Send(new GetLibroByIdQuery { LibroId = id });
            return response;
        }
    }
}
