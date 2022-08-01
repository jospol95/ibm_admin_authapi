using IBMAuthApi.Api.Exceptions;
using IBMAuthApi.Api.Services.Usuarios;
using IBMAuthApi.Api.ViewModels;
using System.Threading.Tasks;

namespace IBMAuthApi.Api.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly IUsuariosService _usuariosService;

        public RegisterService(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }
        public async Task RegisterUser(RegisterDto registerDto)
        {
            var user = await _usuariosService.GetUserByUserName(registerDto.UserName);
            var userAlreadyExists = user != null;
            if (userAlreadyExists)
            {
                throw new UserAlreadyExistsException();
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            await _usuariosService.RegisterUser(registerDto.UserName, passwordHash, registerDto.RolId);
        }

        //public void ComputePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using var hmac = new System.Security.Cryptography.HMACSHA512();
        //    passwordSalt = hmac.Key;
        //    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //}
    }
}
