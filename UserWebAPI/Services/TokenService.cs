using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserWebAPI.Models;

namespace UserWebAPI.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("userName", user.UserName),
                new Claim("Email", user.Email),
                new Claim("id", user.Id),
                new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString()),
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9AS9DA9DA9SAS9DAS9DA9SAD9ASDD9F9"));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
