using System.Text;
using Application.Services.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api.Config;

public static class AddServices
{
    public static void AddJwt(this IServiceCollection service, IConfiguration configuration)
    {
        var jwtKey = configuration.GetSection("Jwt:Key").Value;
        var jwtExpireInMinutes = configuration.GetSection("Jwt:ExpiryInMinutes").Value;

        service.AddScoped(opt => new Jwt(jwtKey, int.Parse(jwtExpireInMinutes)));
    }

    public static void AddJwtAuthentication(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddAuthorization();
        service.AddAuthentication(x => 
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt => 
        {
            opt.TokenValidationParameters = new TokenValidationParameters() 
            {
                ValidateActor = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Key").Value)),
            };
        });
    }
}
