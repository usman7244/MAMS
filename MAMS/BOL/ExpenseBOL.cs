using DAL;
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
    public class ExpenseBOL
    {
        private ExpenseDAL _objExpenseDAL;
        private DAL.CommonDAL _objCommonDAL;

        public ExpenseBOL()
        {
            _objExpenseDAL = new ExpenseDAL();
            _objCommonDAL = new DAL.CommonDAL();
        }
        public async Task<List<Expense>> GetExpenseInfo(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objExpenseDAL.GetExpenseInfo(expense, sqlConnectionFactory);
        }
        public async Task<string> Update(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            string Status=string.Empty;
            Status = await _objExpenseDAL.Update(expense, sqlConnectionFactory);
            if (expense.Type == "DailyExpense")
            {
                if (Status == "Success")
                {

                    if (decimal.TryParse(expense.DiffCash.ToString(), out decimal diffCash) && decimal.TryParse(expense.Amount.ToString(), out decimal totalCash))
                    {
                        var diff = Convert.ToInt32(diffCash- totalCash);
                        if (diff < 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = expense.BranchId,
                                CashLost = diff.ToString().Replace("-", ""),
                                Details = EnumExtension.GetDisplayName(ExpenseType.DailyExpense),

                            };


                            var re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, sqlConnectionFactory);
                            return re;
                        }
                        else if (diff > 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = expense.BranchId,
                                CashProfit = diff.ToString(),
                                Details = EnumExtension.GetDisplayName(ExpenseType.DailyExpense),

                            };


                            var re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, sqlConnectionFactory);
                            return re;
                        }

                    }
                    

                }
              
            }

            return Status;
        }

        public async Task<int> Delete(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            var res = await _objExpenseDAL.Delete(expense, sqlConnectionFactory);
            return res;
        }

        public async Task<string> Insert(Expense model, ISqlConnectionFactory sqlConnectionFactory)
        {
            string Status = "";
             Status = await _objExpenseDAL.Insert(model, sqlConnectionFactory);
            return Status;
        }



        public async Task<Expense> GetSpecificExpenseInfo(int Id, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objExpenseDAL.GetSpecificExpenseInfo(Id, sqlConnectionFactory);
        }
        public async Task<int> ExpenseEdit(Expense model, ISqlConnectionFactory sqlConnectionFactory)
        {
            int affectedRows = 0;
            if (model != null)
            {
                affectedRows = await _objExpenseDAL.ExpenseEdit(model, sqlConnectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
    }
}
