using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BOL;
using DAL.Sql;
using System.Threading.Tasks;
using MAMS_Models.Extenions;
using Newtonsoft.Json;
using static MAMS_Models.Enums.EnumTypes;
using System.Linq;
using System.Xml.Schema;

namespace MAMS.Controllers
{
    public class SaleController : Controller
    {
        private CropBOL _objCropBOL;
        private PurchaseBOL _objPurchaseBOL;
        private CustomerType _custType;
        private List<CustomerType> _custTypeList;
        private List<CropAndBag> _crops;
        private List<CropAndBag> _bags;
        private CashHistory _cashHistory;
        private Purchase _purchase;
        private List<Purchase> _purchaseList;
        private Expense _expense;
        private CropAndBag _crop;
        private List<Expense> _expenseList;
        private ExpenseBOL _objExpenseBOL;
        private readonly ISqlConnectionFactory _connectionFactory;




        private Sale _sale;
        private List<Sale> _saleList;
        private SaleBOL _objSALEBOL;
        private CommonBOL _objCommonBOL;

        public SaleController(ISqlConnectionFactory connectionFactory)
        {
            _objCropBOL = new CropBOL();
            _custType = new CustomerType();
            _custTypeList = new List<CustomerType>();
            _objPurchaseBOL = new PurchaseBOL();
            _cashHistory = new CashHistory();
            _crops = new List<CropAndBag>();
            _bags = new List<CropAndBag>();
            _purchase = new Purchase();
            _purchaseList = new List<Purchase>();
            _expense = new Expense();
            _expenseList = new List<Expense>();
            _crop = new CropAndBag();
            _objExpenseBOL = new ExpenseBOL();
            _connectionFactory = connectionFactory;
            _objCommonBOL = new CommonBOL();



            _objSALEBOL = new SaleBOL();
            _sale = new Sale();
            _saleList = new List<Sale>();

        }
        public async Task<IActionResult> Index()
        {
            _saleList = new List<Sale>();
            _sale = new Sale();

            _sale.BranchId = Guid.Empty;
            _sale.CreatedBy = Guid.Empty;

            _saleList =await _objSALEBOL.GetAllSaleCrop(_sale, _connectionFactory);
            //_expenseList = await _objPurchaseBOL.GetPurchasedExpenseById(Id, _connectionFactory);
            //_expenseList = _expenseList.Select(expense =>
            //{
            //    expense.IsOld = true;
            //    return expense;
            //}).ToList();

            ViewBag.Expenses = _expenseList;
            return View(_saleList);
        }
        public async Task<IActionResult> SaleCrop()
        {
            _crops = new List<CropAndBag>();
            _bags = new List<CropAndBag>();
            _cashHistory = new CashHistory();

            _crop = new CropAndBag();
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Crop);
            _crops = await _objCropBOL.GetCropInfo(_crop, _connectionFactory);
            _cashHistory = await _objPurchaseBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);
            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Bag);
            _bags = await _objPurchaseBOL.GetBags(_crop.BranchId, _crop.CreatedBy,_crop.Type, _connectionFactory);

            ViewBag.Crops = _crops;
            ViewBag.Bags = _bags;
            ViewBag.CashHistory = _cashHistory.TotalCash == null ? "00" : _cashHistory.TotalCash;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaleCropAdd(Sale sale, Expense[] expItems)
        {
            sale.CreatedBy = Guid.Empty;
            sale.BranchId = Guid.Empty;


            List<Expense> expenseList = new List<Expense>();
            foreach (var item in expItems)
            {
                item.CreatedBy = Guid.Empty;
                item.BranchId = Guid.Empty;
                item.Type = EnumExtension.GetDisplayName(ExpenseType.Purchase);
                expenseList.Add(item);
            }

            string response = await _objSALEBOL.SaleCropAdd(sale, expenseList, _connectionFactory);
            response = JsonConvert.SerializeObject(response);
            return Json(new { success = "true", data = new { response, Error = "false" } });
        }
        [HttpPost]
        public IActionResult DeleteSaleCrop(int saleCropId)
        {
            _sale = new Sale();
            _sale.UID = saleCropId;
            _sale.ModifiedBy = Guid.Empty;
            var affectedRows = _objSALEBOL.DeleteSaleCrop(_sale, _connectionFactory);
            //return Ok(affectedRows);
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> SaleCropEdit(int Id)
        {
            _crops = new List<CropAndBag>();
            _bags = new List<CropAndBag>();
            _cashHistory = new CashHistory();
            _sale = new Sale();
            _expenseList = new List<Expense>();
            _custTypeList = new List<CustomerType>();
            _crop = new CropAndBag();
            _crop.CreatedBy = Guid.Empty;
            _crop.BranchId = Guid.Empty;
            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Crop);
            _crops = await _objCropBOL.GetCropInfo(_crop, _connectionFactory);



            _cashHistory = await _objPurchaseBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);
         

            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Bag);
            _bags = await _objPurchaseBOL.GetBags(_crop.BranchId, _crop.CreatedBy, _crop.Type, _connectionFactory);
            _sale = await _objSALEBOL.GetSaleCropById(Id, _connectionFactory);
            _expenseList = await _objSALEBOL.GetSaleExpenseById(Id, _connectionFactory);
            _sale.DiffCash = _sale.TotalCropPrice.ToString();
            _custTypeList = await _objCommonBOL.GetCustomerType(_sale.FK_CustomerType, _crop.BranchId, _crop.CreatedBy, _connectionFactory);
            ViewBag.Crops = _crops;
            ViewBag.Bags = _bags;
            ViewBag.CashHistory = _cashHistory.TotalCash;
            ViewBag.Expenses = _expenseList;
            ViewBag.CustomersTypeList = _custTypeList;

            return View(_sale);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSaleCrop(Sale model, Expense[] expItems)
        {
            try
            {
                model.ModifiedBy = Guid.Empty;
                var res = await _objSALEBOL.UpdateSaleCrop(model, _connectionFactory);


                foreach (var item in expItems)
                {

                    if (item.UID == 0)
                    {
                        item.Fk_Sale= model.UID;
                        item.CreatedBy = Guid.Empty;
                        item.BranchId = Guid.Empty;
                        item.Type = EnumExtension.GetDisplayName(ExpenseType.Saled);
                        var insertexp = await _objExpenseBOL.Insert(item, _connectionFactory);

                    }
                    else
                    {
                        item.ModifiedBy = Guid.Empty;
                        var insertexp = await _objExpenseBOL.Update(item, _connectionFactory);

                    }
                }

                var response = JsonConvert.SerializeObject("Success");
                return Json(new { success = "true", data = new { response, Error = "false" } });
            }
            catch (Exception ex)
            {

                var response = JsonConvert.SerializeObject(ex.Message);
                return Json(new { success = "false", data = new { response, Error = "true" } });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSaleCropWithExpense(Sale model, Expense expItem)
        {
            try
            {
                model.ModifiedBy = Guid.Empty;
                expItem.ModifiedBy = Guid.Empty;
                var res = await _objSALEBOL.UpdateSaleCrop(model, _connectionFactory);
                var delexp = await _objExpenseBOL.Delete(expItem, _connectionFactory);

                var response = JsonConvert.SerializeObject("Success");
                return Json(new { success = "true", data = new { response, Error = "false" } });
            }
            catch (Exception ex)
            {

                var response = JsonConvert.SerializeObject(ex.Message);
                return Json(new { success = "false", data = new { response, Error = "true" } });
            }
        }
        public async Task<IActionResult> StockSale(int Id)
        {

            _crops = new List<CropAndBag>();
            _bags = new List<CropAndBag>();
            _cashHistory = new CashHistory();
            _purchase = new Purchase();
            _expenseList = new List<Expense>();
            _custTypeList = new List<CustomerType>();
            _crop = new CropAndBag();
            _crop.CreatedBy = Guid.Empty;
            _crop.BranchId = Guid.Empty;
            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Crop);

            _crops = await _objCropBOL.GetCropInfo(_crop, _connectionFactory);
            _cashHistory = await _objPurchaseBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);

            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Bag);
            _bags = await _objPurchaseBOL.GetBags(_crop.BranchId, _crop.CreatedBy, _crop.Type, _connectionFactory);
            _purchase = await _objPurchaseBOL.GetPurchasedCropById(Id, _connectionFactory);
            _expenseList = await _objPurchaseBOL.GetPurchasedExpenseById(Id, _connectionFactory);
            //_expenseList = _expenseList.Select(expense =>
            //{
            //    expense.IsOld = true;
            //    return expense;
            //}).ToList();
            _custTypeList = await _objPurchaseBOL.GetCustomerType(_purchase.CustomerType, _crop.BranchId, _crop.CreatedBy, _connectionFactory);
            var _sale = new Sale
            {
                FK_CustomerType = _purchase.CustomerType,
                Fk_Customer=_purchase.Fk_CustomerId,
                Fk_Crop=_purchase.Fk_Crop,
                BagTotal = _purchase.BagTotal,
                BagWeight = _purchase.BagWeight,
                PriceInMaun = _purchase.PriceInMaun,
                PriceInKg = _purchase.PriceInKg,
                CreatedBy = _purchase.CreatedBy,
                CropName = _purchase.CropName,
                TotalCropWeight=_purchase.TotalCropWeight,
               
          
                PurchaseExp = _purchase.TotalAmountwithExp,
                PurchasePrice=_purchase.TotalCropPrice,
                WeightInMaun = _purchase.WeightInMaun,
                WeightInkg= _purchase.WeightInkg,
                FK_BagType=_purchase.FK_BagType,
                TotalExp=_purchase.TotalExp,
                TotalCropPrice = _purchase.TotalCropPrice,
                BranchId =_purchase.BranchId,
                UID= _purchase.UID,
                
            };

            ViewBag.Crops = _crops;
            ViewBag.Bags = _bags;
            ViewBag.CashHistory = _cashHistory.TotalCash;
            ViewBag.Expenses = _expenseList;
            ViewBag.CustomersTypeList = _custTypeList;

            return View(_sale);

       
        }

        [HttpPut]
        public async Task<IActionResult> StockSaleAdd(Sale model, Expense[] expItems)
        {
          
            model.CreatedBy = Guid.Empty;
            model.BranchId = Guid.Empty;

           List<Expense> expenseList = new List<Expense>();
            foreach (var item in expItems)
            {
                item.CreatedBy = Guid.Empty;
                item.BranchId = Guid.Empty;
                item.Type = EnumExtension.GetDisplayName(ExpenseType.Saled);
                expenseList.Add(item);
            }

            try
            {
                
                string response = await _objSALEBOL.StockSaleAdd(model, expenseList, _connectionFactory);
                response = JsonConvert.SerializeObject(response);

            
                if (response == "\"Success\"") 
                {
                    var _purchase = new Purchase
                    {
                        Fk_CustomerId = model.Fk_Customer,
                        UID=model.UID,
                        ModifiedBy=model.ModifiedBy
                    };

            
                    await _objPurchaseBOL.DeletePurchaseCrop(_purchase, _connectionFactory);
                }

                  return Json(new { success = true, data = new { response, Error = false } });
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
                return Json(new { success = false, data = new { response = ex.Message, Error = true } });
            }
        }



    }
}
