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
   
        private LoginDAL _objLoginDAL;
        public LoginBOL()
        {
            _objLoginDAL = new LoginDAL();
        }
        public async Task<User> Authenticate(User user, ISqlConnectionFactory connectionFactory)
        {
            User result = await _objLoginDAL.Authenticate(user, connectionFactory);
            return result;
        }

    }
}
