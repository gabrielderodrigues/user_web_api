using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserWebAPI.Data.Dto.User;
using UserWebAPI.Models;
using UserWebAPI.Services;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            await _userService.CreateAsync(userDto);
            return Ok($"Usuário Cadastrado!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(LoginUserDto dto)
        {
            var tokenResult = await _userService.Authenticate(dto);
            return Ok(tokenResult);
        }
    }
}
