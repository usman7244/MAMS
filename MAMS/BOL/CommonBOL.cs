using DAL;
using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public  class CommonBOL
    {
        private CommonDAL _ObjCommonDAL;
        private CompanyDAL _objCompanyDAL;
        private BranchDAL _objBranchDAL;

        public CommonBOL()
        {
            _objCompanyDAL = new DAL.CompanyDAL();
            _ObjCommonDAL = new DAL.CommonDAL();
            _objBranchDAL=new DAL.BranchDAL();
        }

        public async Task<List<CustomerType>> GetCustomerType(string cusType, Guid branchId, Guid createdBy, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _ObjCommonDAL.GetCustomerType(cusType, branchId, createdBy, sqlConnectionFactory);
        }
        public async Task<List<CashHistory>> GetAllCashHistoryInfo(CashHistory cashHistory, ISqlConnectionFactory connectionFactory)
        {
            var result = await _ObjCommonDAL.GetAllCashHistoryInfo(cashHistory, connectionFactory);
            return result;
        }
        public async Task<CashHistory> GetCashHistory(Guid branchId, Guid createdBy, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _ObjCommonDAL.GetCashHistory(branchId, createdBy, sqlConnectionFactory);
        }
        public async Task<List<Company>> GetCompanies( ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCompanyDAL.GetCompanyInfo( connectionFactory);
            return result;
        }
        public async Task<List<Branch>> GetBranches(ISqlConnectionFactory connectionFactory)
        {
            var result = await _objBranchDAL.GetBranchInfo(connectionFactory);
            return result;
        }
        public async Task<List<Role>> GetRole(ISqlConnectionFactory connectionFactory)
        {
            var result = await _ObjCommonDAL.GetRole(connectionFactory);
            return result;
        }
    }
}
