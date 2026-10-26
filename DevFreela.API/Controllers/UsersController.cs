using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult Get(string? query)
        {
            var users = _userService.GetAll(query);

            if (users == null) return NotFound();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            var userId = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new {id = userId}, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUpdateInputModel inputModel)
        {
            var user = _userService.GetById(id);

            if (user == null) return NotFound();

            _userService.Update(id, inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);

            if (user == null) return NoContent();

            _userService.Delete(id);

            return NoContent();
        }
    }
}
