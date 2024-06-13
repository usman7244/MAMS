using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class BranchBOL
    {
        private DAL.BranchDAL _objBranchDAL;
        public BranchBOL()
        {
            _objBranchDAL = new DAL.BranchDAL();

        }
        public async Task<List<Branch>> GetBranchInfo( ISqlConnectionFactory connectionFactory)
        {
            var result = await _objBranchDAL.GetBranchInfo( connectionFactory);
            return result;
        }
        public async Task<int> BranchAdd(Branch branch, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (branch != null)
            {
                affectedRows = await _objBranchDAL.BranchAdd(branch, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public Task<int> DeleteBranch(Branch branch, ISqlConnectionFactory connectionFactory)
        {
            return _objBranchDAL.DeleteBranch(branch, connectionFactory);
        }
        public async Task<Branch> GetSpecificBranchInfo(Guid Id, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objBranchDAL.GetSpecificBranchInfo(Id, connectionFactory);
            return result;
        }
        public async Task<int> EditBranch(Branch branch, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (branch != null)
            {
                affectedRows = await _objBranchDAL.EditBranch(branch, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }



    }
}
