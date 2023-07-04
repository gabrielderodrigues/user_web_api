using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserWebAPI.Data.Dto.User;
using UserWebAPI.Models;

namespace UserWebAPI.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;

    public UserService(IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task CreateAsync(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário!");
    }

    public async Task<string> Authenticate(LoginUserDto dto)
    {
        var loginResult = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

        if (loginResult.Succeeded) throw new ApplicationException("User not authenticated.");

        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.UserName == dto.UserName.ToUpper());

        var tokenResult = _tokenService.GenerateToken(user);

        return tokenResult;
    }
}
