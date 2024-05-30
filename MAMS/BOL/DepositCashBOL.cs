using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace BOL
{
    public class DepositCashBOL
    {
        private DAL.DepositCashDAL _objCashDAL;
        private DAL.CommonDAL _objCommonDAL;
        public DepositCashBOL()
        {
            _objCashDAL = new DAL.DepositCashDAL();
            _objCommonDAL = new DAL.CommonDAL();
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
        public async Task<string> DeleteDeposit(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            string result = "";
             result = await _objCashDAL.DeleteDeposit(deposit, connectionFactory);

            return result;
        }
        public async Task<string> UpdateDeposit(Deposit deposit, ISqlConnectionFactory connectionFactory)

        {
            string affectedrow=string.Empty;
             affectedrow = await _objCashDAL.UpdateDeposit(deposit, connectionFactory);
            if (deposit.Status == "Sent")
            {
                if (affectedrow == "Success")
                {

                    if (decimal.TryParse(deposit.DiffCash, out decimal diffCash) && decimal.TryParse(deposit.TotalCash, out decimal totalCash))
                    {
                        var diff = Convert.ToInt32(diffCash- totalCash);
                        if (diff < 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = deposit.BranchId,
                                CashLost = diff.ToString().Replace("-", ""),
                                Details = EnumExtension.GetDisplayName(ExpenseType.Deposit),

                            };


                            string re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, connectionFactory);
                            return re;
                        }
                        else if (diff > 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = deposit.BranchId,
                                CashProfit = diff.ToString(),
                                Details = EnumExtension.GetDisplayName(ExpenseType.Deposit),
                            };


                            string re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, connectionFactory);
                            return re;
                        }

                    }
                    else
                    {

                        throw new ArgumentException("Invalid numeric value for DiffCash or TotalCash.");
                    }

                }
                else
                {
                    throw new ArgumentException("Invalid numeric value for DiffCash or TotalCash.");
                }
            }
            return affectedrow;
        }

    }
}
