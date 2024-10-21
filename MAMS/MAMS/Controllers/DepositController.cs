using BOL;
using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using MAMS.CustomFilters;
using Microsoft.AspNetCore.Authorization;

namespace MAMS.Controllers
{
    
    [IdentityUser]
    public class DepositController : BaseController
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _deposit = new Deposit();
            //_deposit.BranchId = GetBranchId();
            _deposit.BranchId = GetBranchId();
            _deposit.CreatedBy = Guid.Empty;

            
            List<Deposit> depositList = await _objCashBOL.GetAllDepositInfo(_deposit, _connectionFactory);

            return View(depositList);
        }
        public async Task<IActionResult> DepositAdd()
        {
            _crop.BranchId = GetBranchId();
            _crop.CreatedBy = GetUserId();
            _cashHistory = await _objCommonBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);
            ViewBag.CashHistory = _cashHistory?.TotalCash ?? "00";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DepositAdd(Deposit deposit)
        {
            deposit.BranchId = GetBranchId();
            deposit.CreatedBy = GetUserId();
           
            //if (deposit != null)
            //{
            //    affectedRows = await _objCashBOL.DepositAdd(deposit, _connectionFactory);
            //    if (affectedRows== "Success")
            //    {
            //        ViewBag.DepositAddStatus = affectedRows;
            //    }
            //}
            if (deposit != null)
            {
                var Result = await _objCashBOL.DepositAdd(deposit, _connectionFactory);
                var affectedRows = Result.AffectedRows;
                if (affectedRows > 0)
                {
                    ViewBag.DepositAddStatus = affectedRows;


                }

            }

            return View();
        }
        public async Task<IActionResult> EditDeposit(int Id)
        {

            _custTypeList = new List<CustomerType>();

            _crop.BranchId = GetBranchId();
            _crop.CreatedBy = GetUserId();
            _deposit = await _objCashBOL.GetAllDepositById(Id, _connectionFactory);
            _custTypeList = await _objCommonBOL.GetCustomerType(_deposit.CustomerType, _crop.BranchId, _crop.CreatedBy, _connectionFactory);
            _deposit.DiffCash = _deposit.TotalCash;

            ViewBag.CustomersTypeList = _custTypeList;
            return View(_deposit);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDeposit([FromForm]  Deposit model)
        {
            try
            {

                model.ModifiedDate = DateTime.Now;
                model.ModifiedBy = GetUserId();
                model.BranchId = GetBranchId();
                model.CreatedBy = GetUserId();

                var res = await _objCashBOL.UpdateDeposit(model, _connectionFactory);

                var successResponse = JsonConvert.SerializeObject("\"Success\"");
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
