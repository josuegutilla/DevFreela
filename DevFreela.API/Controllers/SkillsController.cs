using DevFreela.Application.Commands.CreateSkill;
using DevFreela.Application.Commands.DeleteSkill;
using DevFreela.Application.Commands.UpdateSkill;
using DevFreela.Application.Queries.GetAllSkill;
using DevFreela.Application.Queries.GetByIdSkill;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skills = await _mediator.Send(new GetAllSkillQuery());

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var skill = await _mediator.Send(new GetByIdSkillQuery { Id = id});

            if (skill == null) return NotFound();

            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            var skillId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = skillId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSkillCommand command)
        {
            command.Id = id;

            var skillUpdate = await _mediator.Send(command);

            if (!skillUpdate) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skillDelete = await _mediator.Send(new DeleteSkillCommand { Id = id});

            if (!skillDelete) return NotFound();

            return NoContent();
        }
    }
}
