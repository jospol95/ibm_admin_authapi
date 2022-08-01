using IBMAuthApi.Api.ViewModels;
using System.Threading.Tasks;

namespace IBMAuthApi.Api.Services.Register
{
    public interface IRegisterService
    {
        Task RegisterUser(RegisterDto registerDto);
    }
}
