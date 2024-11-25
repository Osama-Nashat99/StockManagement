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
        public LoginResponseModel Login([FromBody] LoginModel model)
        {
            var response = _authService.Authorize(model.Username, model.Password);
            return response;
        } 
    }
}
