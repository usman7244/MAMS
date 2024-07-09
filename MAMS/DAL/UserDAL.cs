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
    public  class UserDAL
    {
        private List<User> _UserList;
        private User _user;

        public UserDAL()
        {
            _UserList = new List<User>();
            _user = new User();
        }
        public async Task<List<User>> GetUserInfo( ISqlConnectionFactory connectionFactory)
        {

            var _UserList = new List<User>();

            try
            {

                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spGetUser] ";

                var User = await connection.QueryAsync<User>(SQLQuery, new { });

                _UserList = User.ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

            return _UserList;
        }
        public async Task<String> UserAdd(User user, ISqlConnectionFactory connectionFactory)
        {
            string result = string.Empty;

            try
            {
                user.UID = Guid.NewGuid();
                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spAddUser] @BranchUID, @Name,@Email,@Phone,@CNIC,@City,@Country,@Address,@Password ,@Status,@RoleID, @CreatedBy";

                result = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new
                {
                    BranchUID=user.BranchUID,
                    Name = user.Name,
                    Email=user.Email,
                    Phone=user.Phone,
                    CNIC=user.CNIC,
                    City=user.City,
                    Country=user.Country,
                    Address=user.Address,
                    Password=user.Password,
                    Status = user.Status,
                    RoleID=user.RoleID,
                    CreatedBy = user.CreatedBy,
                    
                });
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return result;
        }
        public async Task<int> DeleteUser(User user, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteUser] @UID";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = user.UID });

            return effectedRows;
        }
        public async Task<User> GetSpecificUserInfo(Guid Id, ISqlConnectionFactory connectionFactory)
        {
            User user = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetSpecificUser] @UID";

            user = await connection.QueryFirstOrDefaultAsync<User>(SQLQuery, new { UID = Id });

            return user;
        }


        public async Task<int> EditUser(User user, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            try
            {
                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spUpdateUser] @UID, @Name, @Email, @Phone, @CNIC, @City, @Country, @Address, @Password, @Status, @Role ";

                effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = user.UID, Name = user.Name, Email = user.Email, Phone = user.Phone, CNIC = user.CNIC, City = user.City, Country = user.Country, Address = user.Address, Password = user.Password, Status = user.Status, Role = user.RoleID });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return effectedRows;
        }




    }
}
