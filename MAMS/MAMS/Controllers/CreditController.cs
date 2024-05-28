using BOL;
using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace MAMS.Controllers
{
    public class CreditController : Controller
    {
        
        private readonly ISqlConnectionFactory _connectionFactory;
        private Credit _credit;
        private List<CustomerType> _custTypeList;
        private CreditCashBOL _objCashBOL;
        private CustomerType _custType;
        private CropAndBag _crop;
        private CashHistory _cashHistory;
        private CommonBOL _objCommonBOL;
        private List<Credit> _creditList;
      
        public CreditController(ISqlConnectionFactory connectionFactory)
        {
            _crop =new CropAndBag();
            _objCommonBOL =new CommonBOL();
        
            _objCashBOL = new CreditCashBOL();
            _credit = new Credit();
            _connectionFactory = connectionFactory;
            _cashHistory = new CashHistory();
            _custType = new CustomerType();
            _custTypeList = new List<CustomerType>();
           

        }
        public async Task<IActionResult> Index()
        {
            _credit = new Credit();
            _credit.BranchId = Guid.Empty;
            _credit.CreatedBy = Guid.Empty;


            List<Credit> creditList = await _objCashBOL.GetAllCreditInfo(_credit, _connectionFactory);

            return View(creditList);
        }
        public async Task<IActionResult> CreditAdd()
        {
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            _cashHistory = await _objCommonBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);
            ViewBag.CashHistory = _cashHistory.TotalCash == null ? "00" : _cashHistory.TotalCash;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreditAdd(Credit credit)
        {
            credit.BranchId = Guid.Empty;
            credit.CreatedBy = Guid.Empty;
          
            string affectedRows = "";
            if (credit != null)
            {
                affectedRows = await _objCashBOL.CreditAdd(credit, _connectionFactory);
                if (affectedRows == "Success")
                {
                    ModelState.Clear();

                    return Redirect("Index");
                }
               
            }
           
            return View();
        }
    
       
        
        public async Task<IActionResult> EditCredit(int Id)
       {
            
            _custTypeList = new List<CustomerType>();
            
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            _credit = await _objCashBOL.GetAllCreditById(Id, _connectionFactory);
           
            _custTypeList = await _objCommonBOL.GetCustomerType(_credit.CustomerType, _crop.BranchId, _crop.CreatedBy, _connectionFactory);
            _credit.DiffCash = _credit.TotalCash;




            ViewBag.CustomersTypeList = _custTypeList;

            return View(_credit);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCredit(Credit model)
        {

            try
            {
             
                model.ModifiedBy = Guid.Empty;
                var res = await _objCashBOL.UpdateCredit(model, _connectionFactory);

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
        public async Task<IActionResult> DeleteCredit(int ID)
        {

            _credit = new Credit();
            _credit.UID = ID;
            _credit.ModifiedBy = Guid.Empty;
            var affectedRows = _objCashBOL.DeleteCredit(_credit, _connectionFactory);

            //return Ok(affectedRows);
            return RedirectToAction("Index");
        }
    }
}

