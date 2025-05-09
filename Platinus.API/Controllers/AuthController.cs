using Microsoft.AspNetCore.Mvc;
using Platinus.Application.DTOs.Requests;
using Platinus.Application.DTOs.Response;
using Platinus.Application.Interfaces;

namespace Platinus.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortUser), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Auth([FromBody] RequestAuthUser request)
        {
            var response = await _authService.Auth(request);

            return Created(string.Empty, response);
        }
    }
}
