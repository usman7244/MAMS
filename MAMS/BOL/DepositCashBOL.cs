using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class DepositCashBOL
    {
        private DAL.DepositCashDAL _objCashDAL;
        public DepositCashBOL()
        {
            _objCashDAL = new DAL.DepositCashDAL();

        }

        public async Task<List<Deposit>> GetAllDepositInfo(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCashDAL.GetAllDepositInfo(deposit, connectionFactory);
            return result;
        }
        public async Task<string> DepositAdd(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCashDAL.DepositAdd(deposit,  connectionFactory);
            return result;
        }
        public async Task<Deposit> EditDeposit(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.EditDeposit(Id, connectionFactory);

            return result;
        }
        public async Task<Deposit> GetAllDepositById(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.GetAllDepositById(Id, connectionFactory);

            return result;
        }
        public async Task<int> DeleteDeposit(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.DeleteDeposit(deposit, connectionFactory);

            return result;
        }
        public async Task<int> UpdateDeposit(Deposit deposit, ISqlConnectionFactory connectionFactory)

        {
            var res = await _objCashDAL.UpdateDeposit(deposit, connectionFactory);
            return res;
        }

    }
}
