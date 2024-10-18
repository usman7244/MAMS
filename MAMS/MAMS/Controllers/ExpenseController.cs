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
using MAMS.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MAMS.Controllers
{

    [IdentityUser]
    public class ExpenseController : BaseController
    {
        private CashHistory _cashHistory;
        private BOL.ExpenseBOL _objExpenseBOL;
        private Expense _expense;
        private readonly ISqlConnectionFactory _connectionFactory;
        private CropAndBag _crop;
        private CommonBOL _objCommonBOL;
        public ExpenseController(ISqlConnectionFactory connectionFactory)
        {
            _objCommonBOL = new CommonBOL();
            _crop = new CropAndBag();
            _cashHistory = new CashHistory();
            _objExpenseBOL = new BOL.ExpenseBOL();
            _expense = new Expense();
            _connectionFactory = connectionFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _expense = new Expense();
            _expense.CreatedBy = Guid.Empty;
            _expense.BranchId = GetBranchId();
            _expense.Type = EnumExtension.GetDisplayName(ExpenseType.DailyExpense);
            List<Expense> customers = await _objExpenseBOL.GetExpenseInfo(_expense, _connectionFactory);
            return View(customers);
        }
        public async Task<IActionResult> ExpenseAdd()
        {
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            _cashHistory = await _objCommonBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);
            ViewBag.CashHistory = _cashHistory?.TotalCash ?? "00";
            var expenseModel = new Expense();
            return View(expenseModel);
        }
        [HttpPost]
        public async Task<IActionResult> ExpenseAdd(IFormFile[] UserFiles, string expItems)
        {
            var expItemList = JsonConvert.DeserializeObject<List<Expense>>(expItems);
            
            foreach (var item in expItemList)
            {
                try
                {
                    item.CreatedBy = Guid.Empty;
                    item.BranchId = GetBranchId();
                    item.Type = EnumExtension.GetDisplayName(ExpenseType.DailyExpense);

                    Console.WriteLine($"Inserting item: {item.UID}, {item.Type}, {item.CreatedBy}, {item.BranchId}");

                    await _objExpenseBOL.Inserts(item, UserFiles, _connectionFactory);


                    Console.WriteLine($"Successfully inserted item: {item.UID}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error inserting item: {item.UID}, Exception: {ex.Message}");
                }
            }

            

            var response = JsonConvert.SerializeObject("Success");
            //return Json(new { success = "true", data = new { response } });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ExpenseEdit(int Id)
        {
            var expense = await _objExpenseBOL.GetSpecificExpenseInfo(Id, _connectionFactory);
            expense.DiffCash = expense.Amount;

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
