﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Dtos;
using StockManagement.API.Mappers;
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
        public FetchDto<UserDto> FetchUsers([FromBody] FilterDto filterDto)
        {
            var fetchUsersModel = _userService.FetchUsers(filterDto.PageNumber, filterDto.PageSize, filterDto.Search, filterDto.SortBy, filterDto.SortDirection);
            return UsersMapper.ToUserDto(fetchUsersModel);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public UserDto Post([FromBody] UserDto userDto)
        {
            var user = _userService.AddUser(UsersMapper.ToUserEntity(userDto));
            return UsersMapper.ToUserDto(user);
        }

        [Authorize]
        [HttpPut("reset/{id}")]
        public UserDto ResetPassword(int id, [FromBody] ResetPasswordDto resetPasswordDto)
        {
            var user = _userService.UpdatePassword(id, resetPasswordDto.Password);
            return UsersMapper.ToUserDto(user);
        }
    }
}
