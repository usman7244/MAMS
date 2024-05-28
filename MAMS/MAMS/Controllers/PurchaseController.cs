﻿using BOL;
using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace MAMS.Controllers
{
    public class PurchaseController : Controller
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

        public PurchaseController(ISqlConnectionFactory connectionFactory)
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
        }
        public async Task<IActionResult> Index()
        {
            _purchaseList = new List<Purchase>();
            _purchase = new Purchase();

            _purchase.BranchId = Guid.Empty;
            _purchase.CreatedBy = Guid.Empty;

            
            _purchaseList = await _objPurchaseBOL.GetAllPurchasedCrop(_purchase, _connectionFactory); 
            return View(_purchaseList);
        }

        public async Task<IActionResult> PurchaseCrop()
        {
            _crops = new List<CropAndBag>();
            _bags = new List<CropAndBag>();
            _cashHistory = new CashHistory();

            _crop = new CropAndBag();
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;


            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Crop);
            _crops =await _objCropBOL.GetCropInfo(_crop,_connectionFactory);

             _cashHistory =await _objPurchaseBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy, _connectionFactory);
           
            
            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Bag);
            _bags =await _objPurchaseBOL.GetBags(_crop.BranchId, _crop.CreatedBy,_crop.Type,_connectionFactory);

            ViewBag.Crops = _crops;
            ViewBag.Bags = _bags;
            ViewBag.CashHistory = _cashHistory.TotalCash == null ? "00" : _cashHistory.TotalCash;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPurchaseCrop(Purchase purchase, Expense[] expItems)
        {
            purchase.CreatedBy = Guid.Empty;
            purchase.BranchId = Guid.Empty;
            purchase.Status = EnumExtension.GetDisplayName(ExpenseType.Purchase);

            List<Expense> expenseList = new List<Expense>();
            foreach (var item in expItems)
            {
                item.CreatedBy = Guid.Empty;
                item.BranchId = Guid.Empty;
                item.Type = EnumExtension.GetDisplayName(ExpenseType.Purchase);
                expenseList.Add(item);
            }

            string response = await _objPurchaseBOL.AddPurchaseCrop(purchase, expenseList, _connectionFactory);
            response = JsonConvert.SerializeObject(response);
            return Json(new { success = "true", data = new { response, Error = "false" } });
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomerType(string cusType)
        {
            var barnchid = Guid.Empty;
            var userid = Guid.Empty;
            List<CustomerType> customers =await _objPurchaseBOL.GetCustomerType(cusType, barnchid, userid, _connectionFactory);
            return Json(new { success = "true", data = new { customers = customers, Error = "false" } });
        }
        [HttpPost]
        public IActionResult DeletePurchaseCrop(int purchCropId)
        {
            _purchase = new Purchase();
            _purchase.UID = purchCropId;
            _purchase.ModifiedBy = Guid.Empty;
            var affectedRows = _objPurchaseBOL.DeletePurchaseCrop(_purchase, _connectionFactory);
            //return Ok(affectedRows);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> PurchaseCropEdit(int Id)
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
            _crops =await _objCropBOL.GetCropInfo(_crop,_connectionFactory);
            _cashHistory =await _objPurchaseBOL.GetCashHistory(_crop.BranchId, _crop.CreatedBy,_connectionFactory);
            _crop.Type = EnumExtension.GetDisplayName(ExpenseType.Bag);
            _bags =await _objPurchaseBOL.GetBags(_crop.BranchId, _crop.CreatedBy,_crop.Type, _connectionFactory);
            _purchase =await _objPurchaseBOL.GetPurchasedCropById(Id,_connectionFactory);
            _expenseList =await _objPurchaseBOL.GetPurchasedExpenseById(Id, _connectionFactory);
            _custTypeList =await _objPurchaseBOL.GetCustomerType(_purchase.CustomerType, _crop.BranchId, _crop.CreatedBy, _connectionFactory);
            ViewBag.Crops = _crops;
            ViewBag.Bags = _bags;
            ViewBag.CashHistory = _cashHistory.TotalCash;
            ViewBag.Expenses = _expenseList;
            ViewBag.CustomersTypeList = _custTypeList;

            return View(_purchase);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePurchaseCrop(Purchase model, Expense[] expItems)
         {
            try
            {
                model.ModifiedBy = Guid.Empty;
                var res = await _objPurchaseBOL.UpdatePurchaseCrop(model, _connectionFactory);


                foreach (var item in expItems)
                {

                    if (item.UID == 0)
                    {
                        item.Fk_Purchase = model.UID;
                        item.CreatedBy = Guid.Empty;
                        item.BranchId = Guid.Empty;
                        item.Type = EnumExtension.GetDisplayName(ExpenseType.Purchase);
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
        public async Task<IActionResult> UpdatePurchaseCropWithExpense(Purchase model, Expense expItem)
        {
            try
            {
                model.ModifiedBy = Guid.Empty;
                expItem.ModifiedBy = Guid.Empty;
                var res = await _objPurchaseBOL.UpdatePurchaseCrop(model, _connectionFactory);
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
    }
}