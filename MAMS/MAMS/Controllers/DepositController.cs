using BOL;
using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace MAMS.Controllers
{
    public class DepositController : Controller
    {

        private readonly ISqlConnectionFactory _connectionFactory;
        private Deposit _deposit;
        private BOL.DepositCashBOL _objCashBOL;

        private CashHistory _cashHistory;
        private CustomerType _custType;
        private List<CustomerType> _custTypeList;
        private CropAndBag _crop;

        private CommonBOL _objCommonBOL;
        private List<Credit> _creditList;
        public DepositController(ISqlConnectionFactory connectionFactory)
        {
            _crop = new CropAndBag();
            _objCommonBOL = new CommonBOL();
            _cashHistory = new CashHistory();
            _objCashBOL = new DepositCashBOL();
            _deposit = new Deposit();
            _connectionFactory = connectionFactory;
            _custType = new CustomerType();
            _custTypeList = new List<CustomerType>();
        }
        public async Task<IActionResult> Index()
        {
            _deposit = new Deposit();
            _deposit.BranchId = Guid.Empty;
            _deposit.CreatedBy = Guid.Empty;

            
            List<Deposit> depositList = await _objCashBOL.GetAllDepositInfo(_deposit, _connectionFactory);

            return View(depositList);
        }
        public async Task<IActionResult> DepositAdd()
        {
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            _cashHistory = await _objCommonBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);
            ViewBag.CashHistory = _cashHistory?.TotalCash ?? "00";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DepositAdd(Deposit deposit)
        {
            deposit.BranchId = Guid.Empty;
            deposit.CreatedBy = Guid.Empty;
            string affectedRows = "";
            if (deposit != null)
            {
                affectedRows = await _objCashBOL.DepositAdd(deposit, _connectionFactory);
                if (affectedRows== "Success" || affectedRows == "Success - Pending")
                {
                    ModelState.Clear();

                    return Redirect("Index");
                }
            }
            ViewBag.CreditAddStatus = affectedRows;
            return View();
        }
        public async Task<IActionResult> EditDeposit(int Id)
        {

            _custTypeList = new List<CustomerType>();

            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            _deposit = await _objCashBOL.GetAllDepositById(Id, _connectionFactory);
            _custTypeList = await _objCommonBOL.GetCustomerType(_deposit.CustomerType, _crop.BranchId, _crop.CreatedBy, _connectionFactory);
            _deposit.DiffCash = _deposit.TotalCash;

            ViewBag.CustomersTypeList = _custTypeList;
            return View(_deposit);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDeposit(Deposit model)
        {
            try
            {

                model.ModifiedBy = Guid.Empty;
                var res = await _objCashBOL.UpdateDeposit(model, _connectionFactory);

                var successResponse = JsonConvert.SerializeObject("Success");
                return Json(new { success = "true", data = new { res, Error = "false" } });
            }
            catch (Exception ex)
            {
                var errorResponse = JsonConvert.SerializeObject(ex.Message);
                return Json(new { success = "false", data = new { errorResponse, Error = "true" } });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDeposit(int ID)
        {

            _deposit = new Deposit();
            _deposit.UID = ID;
            _deposit.ModifiedBy = Guid.Empty;
            var affectedRows = _objCashBOL.DeleteDeposit(_deposit, _connectionFactory);
            //return Ok(affectedRows);
            return RedirectToAction("Index");
        }


    }
}
