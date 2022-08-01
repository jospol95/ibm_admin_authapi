using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace IBMAuthApi.Api.Services.Login
{
    public interface ILoginService
    {
        Task<JwtSecurityToken> Login(string username, string password);
    }
}
