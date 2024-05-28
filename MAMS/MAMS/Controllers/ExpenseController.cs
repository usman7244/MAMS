using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BOL;
using MAMS_Models.Extenions;
using static MAMS_Models.Enums.EnumTypes;
using Newtonsoft.Json;

namespace MAMS.Controllers
{
    public class ExpenseController : Controller
    {

        private BOL.ExpenseBOL _objExpenseBOL;
        private Expense _expense;
        private readonly ISqlConnectionFactory _connectionFactory;

        public ExpenseController(ISqlConnectionFactory connectionFactory)
        {
            _objExpenseBOL = new BOL.ExpenseBOL();
            _expense = new Expense();
            _connectionFactory = connectionFactory;
        }
        public async Task<IActionResult> Index()
        {
            _expense = new Expense();
            _expense.CreatedBy = Guid.Empty;
            _expense.BranchId = Guid.Empty;
            _expense.Type= EnumExtension.GetDisplayName(ExpenseType.DailyExpense);
            List<Expense> customers = await _objExpenseBOL.GetExpenseInfo(_expense, _connectionFactory);
            return View(customers);
        }
        public IActionResult ExpenseAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ExpenseAdd(Expense[] expItems)
        {

            foreach (var item in expItems)
            {
                item.CreatedBy = Guid.Empty;
                item.BranchId = Guid.Empty;
                item.Type = EnumExtension.GetDisplayName(ExpenseType.DailyExpense);
                await _objExpenseBOL.Insert(item, _connectionFactory);

            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> ExpenseEdit(int Id)
        {
            var expense = await _objExpenseBOL.GetSpecificExpenseInfo(Id, _connectionFactory);

            return View(expense);
        }



        [HttpPost]
        public async Task<IActionResult> ExpenseEdit(Expense model)
        {
            
            model.ModifiedBy = Guid.Empty;


            await _objExpenseBOL.Update(model, _connectionFactory);

            var response = JsonConvert.SerializeObject("Success");
            return Json(new { success = "true", data = new { response } });
        }




        [HttpPost]
        public async Task<IActionResult> DeleteExpense(Expense expItem)
        {
            var affectedRows = await _objExpenseBOL.Delete(expItem, _connectionFactory);
            return Ok(affectedRows);
        }
    }
}
