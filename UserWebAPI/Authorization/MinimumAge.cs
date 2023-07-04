using Microsoft.AspNetCore.Authorization;

namespace UserWebAPI.Authorization;

public class MinimumAge : IAuthorizationRequirement
{
    public int Age { get; set; }

    public MinimumAge(int age)
    {
        Age = age;
    }
}
