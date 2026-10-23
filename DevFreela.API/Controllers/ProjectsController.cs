using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/projects
        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        //GET: api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        //POST: api/projects
        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel project)
        {
            if (project.Title.Length > 50)
            {
                return BadRequest();
            }

            var projectId = _projectService.Create(project);

            return CreatedAtAction(nameof(GetById), new { id = projectId }, project);
        }

        // PUT: api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel project)
        {
            var p = _projectService.GetById(id);

            if (p == null)
            {
                return NotFound();
            } 
            else if (p.Description.Length < 200)
            {
                return BadRequest();
            }

            _projectService.Update(id, project);

            return NoContent();
        }

        // DELETE: api/projects/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var p = _projectService.GetById(id);

            if (p == null)
            {
                return NotFound();
            }

            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            var p = _projectService.GetById(id);

            if (p == null)
            {
                return NotFound();
            }

            _projectService.Finish(id);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel comment)
        {
            var p = _projectService.GetById(id);

            if (p == null)
            {
                return NotFound();
            }

            _projectService.CreateComment(id, comment);

            return NoContent();
        }
    }
}
