using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Platinus.Application.Interfaces;
using Platinus.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Platinus.Application.Services
{
    public class TokenService : ITokenService
    {
        public string Generate(User user)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Platinus.API"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(configuration["AppSettings:PrivateKey"]);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            { 
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
            };


            var token = handler.CreateToken(tokenDescriptor);

            var strToken = handler.WriteToken(token);

            return strToken;
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            ci.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

            return ci;
        }
    }
}
