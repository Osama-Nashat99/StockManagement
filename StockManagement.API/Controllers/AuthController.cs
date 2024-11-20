using Microsoft.AspNetCore.Mvc;
using StockManagement.Domain.Models;
using StockManagement.Domain.Services;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
             var result = _authService.Authorize(model.Username, model.Password);

            if (result.isSuccess == false)
                return Unauthorized(result.message);

            return Ok(new { Token = result.value });
        } 
    }
}
