using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Dtos;
using StockManagement.API.Mappers;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Services;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("fetch")]
        public IActionResult FetchUsers([FromBody] FilterDto filterDto)
        {
            var result = _userService.FetchUsers(filterDto.PageNumber, filterDto.PageSize, filterDto.Search, filterDto.SortBy, filterDto.SortDirection);

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(UsersMapper.ToUserDto(result.value));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post([FromBody] UserDto user)
        {
            var result = _userService.AddUser(UsersMapper.ToUserEntity(user));

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(UsersMapper.ToUserDto(result.value));
        }

        [Authorize()]
        [HttpPut("reset/{id}")]
        public IActionResult ResetPassword(int id, [FromBody] string password)
        {
            var result = _userService.UpdatePassword(id, password);

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(UsersMapper.ToUserDto(result.value));
        }
    }
}
