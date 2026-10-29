using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProject;
using DevFreela.Application.Queries.GetByIdProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/projects
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var projects = await _mediator.Send(new GetAllProjectQuery(query));

            return Ok(projects);
        }

        //GET: api/projects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _mediator.Send(new GetByIdProjectQuery { Id = id });

            if (project == null) return NotFound();

            return Ok(project);
        }

        //POST: api/projects
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            // mais para frente, validar com o fluentValidation
            if (string.IsNullOrWhiteSpace(command.Title) || command.Title.Length <= 5)
            {
                return BadRequest();
            }

            var projectId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = projectId }, command);
        }

        // PUT: api/projects/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            command.Id = id;

            var projectUpdate = await _mediator.Send(command);

            if (!projectUpdate) return NotFound();

            return NoContent();
        }

        // DELETE: api/projects/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _mediator.Send(new DeleteProjectCommand { Id = id});

            if (!project) return NotFound();

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            command.IdProject = id;

            var addComment = await _mediator.Send(command);

            if (!addComment) return NotFound();

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var startProject = await _mediator.Send(new StartProjectCommand { Id = id});

            if (!startProject) return NotFound();

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var finishProject = await _mediator.Send(new FinishProjectCommand { Id = id});

            if (!finishProject) return NotFound();

            return NoContent();
        }
    }
}
