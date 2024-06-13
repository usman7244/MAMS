using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UserBOL
    {
        private DAL.UserDAL _objUserDAL;
        public UserBOL()
        {
            _objUserDAL = new DAL.UserDAL();

        }
        public async Task<List<User>> GetUserInfo( ISqlConnectionFactory connectionFactory)
        {
            var result = await _objUserDAL.GetUserInfo(connectionFactory);
            return result;
        }
        public async Task<int> UserAdd(User user, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (user != null)
            {
                affectedRows = await _objUserDAL.UserAdd(user, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public Task<int> DeleteUser(User user, ISqlConnectionFactory connectionFactory)
        {
            return _objUserDAL.DeleteUser(user, connectionFactory);
        }
        public async Task<User> GetSpecificUserInfo(Guid Id, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objUserDAL.GetSpecificUserInfo(Id, connectionFactory);
            return result;
        }
        public async Task<int> EditUser(User user, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (user != null)
            {
                affectedRows = await _objUserDAL.EditUser(user, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
    }
}
