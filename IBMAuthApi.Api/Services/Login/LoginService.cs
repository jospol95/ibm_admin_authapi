using IBMAuthApi.Api.Exceptions;
using IBMAuthApi.Api.Services.TokenService;
using IBMAuthApi.Api.Services.Usuarios;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace IBMAuthApi.Api.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IUsuariosService _usuariosService;
        private readonly ITokenService _tokenService;

        public LoginService(IUsuariosService usuariosService, ITokenService tokenService)
        {
            _usuariosService = usuariosService;
            _tokenService = tokenService;
        }
        public async Task<JwtSecurityToken> Login(string username, string password)
        {
            var existingUser = await _usuariosService.GetUserByUserName(username);
            if (existingUser == null)
            {
                throw new UserNotFoundException();
            }

            var isPasswordValid = IsPasswordProvidedValid(password, existingUser.PasswordHash);
            if (!isPasswordValid)
            {
                throw new PasswordIncorrectException();
            }

            return _tokenService.CreateToken(existingUser.Id, existingUser.UserName, existingUser.RolId, existingUser.Rol);
        }

        public bool IsPasswordProvidedValid(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }



    }
}
