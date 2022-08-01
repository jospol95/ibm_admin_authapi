using Dapper;
using IBMAuthApi.Api.DataAccess;
using IBMAuthApi.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IBMAuthApi.Api.Services.Usuarios
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IbmDbContext _dbContext;

        public UsuariosService(IbmDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoginModel> GetUserByUserName(string username)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new
                {
                    NombreUsuario = username,
      
                };
                try
                {
                    var userLogin = await connection.QueryAsync<LoginModel>("dbo.ObtenerUsuario",
                        param: parameters,
                        commandType: System.Data.CommandType.StoredProcedure);
                    return userLogin.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task RegisterUser(string username, string passwordHash, int rolId)
        {
            using(var connection = _dbContext.CreateConnection())
            {
                var parameters = new
                {
                    NombreUsuario = username,
                    PasswordHash = passwordHash,
                    RolId = rolId
                };
                try
                {
                    await connection.ExecuteAsync("dbo.RegistrarUsuario", 
                        param: parameters,
                        commandType: System.Data.CommandType.StoredProcedure);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
