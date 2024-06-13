using DAL;
using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class LoginBOL
    {
   
        private DAL.LoginDAL _objLoginDAL;
        public LoginBOL()
        {
            _objLoginDAL = new DAL.LoginDAL();
        }
        public async Task<string> Authenticate(string email,string password,ISqlConnectionFactory connectionFactory)
        {
            string result = string.Empty;
             result = await _objLoginDAL.Authenticate(email,password,connectionFactory);
            return result;
        }
    }
}
