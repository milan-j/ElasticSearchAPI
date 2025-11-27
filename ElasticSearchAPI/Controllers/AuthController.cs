using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchAPI.Controllers
{
    /// <summary>
    /// Controller responsible for user authentication.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService AuthService) : ControllerBase
    {
        /// <summary>
        /// Handles user login and JWT token generation.
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (AuthService.ValidateCretentials(request.Username, request.Password))
            {
                var token = AuthService.GenerateJwtToken(request.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}