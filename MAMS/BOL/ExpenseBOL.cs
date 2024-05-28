using DAL;
using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ExpenseBOL
    {
        private ExpenseDAL _objExpenseDAL;

        public ExpenseBOL()
        {
            _objExpenseDAL = new ExpenseDAL();
        }
        public async Task<List<Expense>> GetExpenseInfo(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objExpenseDAL.GetExpenseInfo(expense, sqlConnectionFactory);
        }
        public async Task<int> Update(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            var res = await _objExpenseDAL.Update(expense, sqlConnectionFactory);
            return res;
        }

        public async Task<int> Delete(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            var res = await _objExpenseDAL.Delete(expense, sqlConnectionFactory);
            return res;
        }

        public async Task<int> Insert(Expense model, ISqlConnectionFactory sqlConnectionFactory)
        {
            
            var res = await _objExpenseDAL.Insert(model, sqlConnectionFactory);
            return res;
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
