using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDAL
    {
        public async Task<string> Authenticate(string email, string password, ISqlConnectionFactory connectionFactory)
        {
            Login login = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetUserByEmail] @Email";

            login = await connection.QueryFirstOrDefaultAsync<Login>(SQLQuery, new { Email = email });

            if (login != null && login.Password == password)
            {
                return "Success";
            }
            else
            {
                return "Invalid";
            }
        }
    }
}
