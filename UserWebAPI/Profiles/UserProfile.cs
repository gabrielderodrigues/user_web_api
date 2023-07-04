using AutoMapper;
using UserWebAPI.Data.Dto.User;
using UserWebAPI.Models;

namespace UserWebAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
