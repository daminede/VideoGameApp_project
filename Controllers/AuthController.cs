using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Auth;

namespace VideoGameApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authService;

        public AuthController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] VideoGameApp.Auth.RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);
            return Ok(new { message = result });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] VideoGameApp.Auth.LoginModel model)
        {
            var token = await _authService.LoginAsync(model);
            if (token == "Invalid username or password.")
                return Unauthorized(new { message = token });

            return Ok(new { token });
        }
    }
}
