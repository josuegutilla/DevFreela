using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.DeleteUser;
using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Application.Queries.GetAllUser;
using DevFreela.Application.Queries.GetByIdUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetByIdUserQuery { Id = id});

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = userId}, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            var user = await _mediator.Send(command);

            if (!user) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _mediator.Send(new DeleteUserCommand { Id = id});

            if (!user) return NotFound();

            return NoContent();
        }
    }
}
