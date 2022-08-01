using System.IdentityModel.Tokens.Jwt;

namespace IBMAuthApi.Api.Services.TokenService
{
    public interface ITokenService
    {
        JwtSecurityToken CreateToken(int id, string username, int rolId, string rol);
    }
}
