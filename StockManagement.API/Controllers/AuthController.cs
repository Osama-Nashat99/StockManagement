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

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                var result = _authService.Authorize(model.Username, model.Password);

                if (result.isSuccess == false)
                    return StatusCode(result.code.GetHashCode(), result.message);

                return Ok(result.value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        } 
    }
}
