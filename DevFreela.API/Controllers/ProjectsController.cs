using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        // GET: api/projects
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok(new { message = "Hello World!" });
        }

        //GET: api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { message = $"Hello World! {id}" });
        }

        //POST: api/projects
        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        // PUT: api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project project)
        {
            return NoContent();
        }

        // DELETE: api/projects/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] ProjectComment comment)
        {
            return NoContent();
        }
    }
}
