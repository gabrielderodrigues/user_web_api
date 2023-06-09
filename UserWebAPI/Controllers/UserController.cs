using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserWebAPI.Data.Dto.User;
using UserWebAPI.Models;
using UserWebAPI.Services;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserAppService _userAppService;

        public UserController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            await _userAppService.CreateAsync(userDto);
            return Ok($"Usuário Cadastrado!");
        }
    }
}
