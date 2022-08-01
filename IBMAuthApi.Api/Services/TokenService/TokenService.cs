using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IBMAuthApi.Api.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public JwtSecurityToken CreateToken(int id, string username, int rolId, string rol)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _config["JwtSettings:Subject"]),
                new Claim("Id", id.ToString()),
                new Claim("UserName", username.ToString()),
                new Claim("Rol", rol.ToString()),
                new Claim("RolId", rolId.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"], _config["JwtSettings:Audience"], claims, 
                expires: DateTime.UtcNow.AddDays(30), signingCredentials: signIn);
            return token;
        }
    }
}
