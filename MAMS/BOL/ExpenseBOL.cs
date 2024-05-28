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

        public async Task<int> Insert(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            var res = await _objExpenseDAL.Insert(expense, sqlConnectionFactory);
            return res;
        }
    }
}
