using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProject;
using DevFreela.Application.Queries.GetByIdProject;
using DevFreela.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/projects
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string? query)
        {
            var projects = await _mediator.Send(new GetAllProjectQuery(query));

            return Ok(projects);
        }

        //GET: api/projects/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _mediator.Send(new GetByIdProjectQuery { Id = id });

            if (project == null) return NotFound();

            return Ok(project);
        }

        //POST: api/projects
        [HttpPost]
        [Authorize(Roles = "client")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            command.IdClient = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var projectId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = projectId }, null);
        }

        // PUT: api/projects/1
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            command.Id = id;
            command.IdUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); 

            var result = await _mediator.Send(command);

            return result switch
            {
                ProjectCommandResult.NotFound => NotFound(),
                ProjectCommandResult.Forbidden => Forbid(),      // ← 403    
                _ => NoContent()
            };
        }

        // DELETE: api/projects/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            command.IdUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _mediator.Send(command);

            return result switch
            {
                ProjectCommandResult.NotFound => NotFound(),
                ProjectCommandResult.Forbidden => Forbid(),
                _ => NoContent()
            };
        }

        [HttpPost("{id}/comments")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            command.IdProject = id;
            command.IdUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var addComment = await _mediator.Send(command);

            if (!addComment) return NotFound();

            return NoContent();
        }

        [HttpPut("{id}/start")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand { Id = id };
            command.IdUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _mediator.Send(command);

            return result switch
            {
                ProjectCommandResult.NotFound => NotFound(),
                ProjectCommandResult.Forbidden => Forbid(),
                _ => NoContent()
            };
        }

        [HttpPut("{id}/finish")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand { Id = id };
            command.IdUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _mediator.Send(command);

            return result switch
            {
                ProjectCommandResult.NotFound => NotFound(),
                ProjectCommandResult.Forbidden => Forbid(),
                _ => NoContent()
            };
        }
    }
}
