using Application.Commands;
using Application.DTOs;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UsuarioDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UsuarioDto>>> Get()
        {
            var query = new GetUsuariosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUsuarioCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUsuarioCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
