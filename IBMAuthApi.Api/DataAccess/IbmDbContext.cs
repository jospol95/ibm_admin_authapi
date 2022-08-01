using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IBMAuthApi.Api.DataAccess
{
    public class IbmDbContext 
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public IbmDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ibm_sql");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

    }
}
