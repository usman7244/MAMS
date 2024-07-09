using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL
{
    public  class BranchDAL
    {
        private List<Branch> _branchList;
        private Branch _branch;

        public BranchDAL()
        {
            _branchList = new List<Branch>();
            _branch = new Branch();
        }
        public async Task<List<Branch>> GetBranchInfo( ISqlConnectionFactory connectionFactory)
        {

            var _branchList = new List<Branch>();

            try
            {

                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spGetBranch] ";

                var Branch = await connection.QueryAsync<Branch>(SQLQuery, new {  });

                _branchList = Branch.ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

            return _branchList;
        }
        public async Task<int> BranchAdd(Branch branch, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;

            try
            {
                branch.UID = Guid.NewGuid();
                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spAddBranch] @Name,@CompanyUID,@Address, @Status, @CreatedBy";

                affectedRows = await connection.ExecuteAsync(SQLQuery, new
                {
                    Name = branch.Name,
                    CompanyUID=branch.CompanyUID,
                    Address=branch.Address,
                    Status = branch.Status,
                    CreatedBy = branch.CreatedBy

                });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return affectedRows;
        }
        public async Task<int> DeleteBranch(Branch branch, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteBranch] @UID";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = branch.UID });

            return effectedRows;
        }
        public async Task<Branch> GetSpecificBranchInfo(Guid Id, ISqlConnectionFactory connectionFactory)
        {
            Branch branch = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetSpecificBranch] @UID";

            branch = await connection.QueryFirstOrDefaultAsync<Branch>(SQLQuery, new { UID = Id });

            return branch;
        }


        public async Task<int> EditBranch(Branch branch, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spUpdateBranch] @UID, @Name,@Address, @ModifiedBy,@Status";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = branch.UID, Name = branch.Name,Address=branch.Address, ModifiedBy = branch.ModifiedBy, Status = branch.Status });

            return effectedRows;
        }
    }
}
