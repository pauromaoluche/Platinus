using Microsoft.AspNetCore.Mvc;
using Platinus.Application.DTOs.Requests;
using Platinus.Application.DTOs.Response;
using Platinus.Application.Interfaces.User;

namespace Platinus.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
 
        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllUser), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();

            if(response.Users.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortUser), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RequestUser request)
        {
            var response = await _userService.CreateUser(request);

            return Created(string.Empty, response);
        }
    }
}
