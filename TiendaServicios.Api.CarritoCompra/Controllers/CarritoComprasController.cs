using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Shared.Common;
using TiendaServicios.CarritoCompra.Application.DTOs;
using TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Commands.Create;
using TiendaServicios.CarritoCompra.Application.Features.CarritoCompra.Queries.GetCarritosById;

namespace TiendaServicios.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarritoComprasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Crear([FromBody] CreateCarritoCompraCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return response;
            }
            catch (ValidationException ex)
            {
                var errores = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });

                return BadRequest(new { Errors = errores });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CarritoDto>>> GetCarrito(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetCarritosByIdQuery { CarritoSesionId = id });
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarritoDto>(false, ex.Message, null!);
            }
        }
    }
}
