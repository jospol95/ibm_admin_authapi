using IBMAuthApi.Api.Models;
using System.Threading.Tasks;

namespace IBMAuthApi.Api.Services.Usuarios
{
    public interface IUsuariosService
    {
        Task<LoginModel> GetUserByUserName(string username);
        Task RegisterUser(string username, string passwordHash, int rolId);
    }
}
