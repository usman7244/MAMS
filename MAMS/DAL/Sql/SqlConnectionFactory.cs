using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Sql
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("IdentityManagementDb");
            return new SqlConnection(connectionString);
        }
    }
}
