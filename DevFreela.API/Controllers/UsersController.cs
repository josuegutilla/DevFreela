using DevFreela.Application.Commands.ActiveUser;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.DeleteUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Application.Queries.GetAllUser;
using DevFreela.Application.Queries.GetByIdUser;
using DevFreela.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // tudo aqui exige login...
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result is null) return Unauthorized();
            
            return Ok(result);
        }

        // GET: api/users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetByIdUserQuery { Id = id});

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = userId}, null);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(HttpValidationProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            var loggedId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (loggedId != id) return Forbid();

            var result = await _mediator.Send(command);

            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(HttpValidationProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {

            var loggedId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (loggedId != id) return Forbid();

            var result = await _mediator.Send(new DeleteUserCommand { Id = id});

            if (!result) return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/active")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(HttpValidationProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Active(int id)
        {
            var loggedId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (loggedId != id) return Forbid();

            var result = await _mediator.Send(new ActiveUserCommand { Id = id });

            if (!result) return NotFound();

            return NoContent();
        }
    }
}
