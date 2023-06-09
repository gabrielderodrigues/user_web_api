using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserWebAPI.Data.Dto.User;
using UserWebAPI.Models;

namespace UserWebAPI.Services
{
    public class UserAppService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserAppService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateAsync(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }
}
