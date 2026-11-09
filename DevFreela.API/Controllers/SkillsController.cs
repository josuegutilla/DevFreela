using DevFreela.Application.Commands.CreateSkill;
using DevFreela.Application.Commands.DeleteSkill;
using DevFreela.Application.Commands.UpdateSkill;
using DevFreela.Application.Queries.GetAllSkill;
using DevFreela.Application.Queries.GetByIdSkill;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var skills = await _mediator.Send(new GetAllSkillQuery());

            return Ok(skills);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var skill = await _mediator.Send(new GetByIdSkillQuery { Id = id});

            if (skill == null) return NotFound();

            return Ok(skill);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            var skillId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = skillId }, command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSkillCommand command)
        {
            command.Id = id;

            var skillUpdate = await _mediator.Send(command);

            if (!skillUpdate) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var skillDelete = await _mediator.Send(new DeleteSkillCommand { Id = id});

            if (!skillDelete) return NotFound();

            return NoContent();
        }
    }
}
