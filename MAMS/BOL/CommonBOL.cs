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

        public CommonBOL()
        {
            _ObjCommonDAL = new DAL.CommonDAL();

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

    }
}
