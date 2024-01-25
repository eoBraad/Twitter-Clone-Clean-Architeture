using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Utility;

public class Jwt
{
    private readonly Byte[] Key;
    private readonly int ExpireInMinutes;
    public Jwt(string key, int minutes)
    {
        Key = Encoding.ASCII.GetBytes(key);;
        ExpireInMinutes = minutes;
    }

    public string GenerateToken(User user)
    {
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("UserId", user.Id.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(ExpireInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenGenerator = tokenHandler.CreateToken(tokenConfig);
        var token = tokenHandler.WriteToken(tokenGenerator);

        return token;
    }

    public static string GetUserByToken(string token)
    {
       var tokenHandler = new JwtSecurityToken(token);
       var userId = tokenHandler.Claims.First(claim => claim.Type == "UserId").Value;
       
       return userId;
    }
}
