using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserWebAPI.Authorization;

public class AuthorizationAge : AuthorizationHandler<MinimumAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
    {
        var birthdayClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if (birthdayClaim is null) return Task.CompletedTask;
        
        var birthday = Convert.ToDateTime(birthdayClaim.Value);

        var userAge = DateTime.Today.Year - birthday.Year;

        if (birthday > DateTime.Today.AddYears(-userAge))
        {
            userAge--;
        }

        if (userAge >= requirement.Age)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
