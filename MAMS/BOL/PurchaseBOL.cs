using DAL;
using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BOL
{
    public class PurchaseBOL
    {
        private PurchaseDAL _objPurchaseDAL;
        private List<Bag> _bags;
        public PurchaseBOL()
        {
            _objPurchaseDAL = new PurchaseDAL();
            _bags = new List<Bag>();
        }
        public List<CustomerType> GetCustomerType(string cusType, Guid branchId, Guid createdBy)
        {
            return _objPurchaseDAL.GetCustomerType(cusType, branchId, createdBy);
        }
        public List<Bag> GetBags(Guid branchId, Guid createdBy)
        {
            return _objPurchaseDAL.GetBags(branchId, createdBy);
        }
        public CashHistory GetCashHistory(Guid branchId, Guid createdBy)
        {
            return _objPurchaseDAL.GetCashHistory(branchId, createdBy);
        }
        public List<Purchase> GetAllPurchasedCrop(Purchase purchase)
        {
            return _objPurchaseDAL.GetAllPurchasedCrop(purchase);
        }
        public Purchase GetPurchasedCropById(int purchCropId)
        {
            return _objPurchaseDAL.GetPurchasedCropById(purchCropId);
        }
        public List<Expense> GetPurchasedExpenseById(int purchCropId)
        {
            return _objPurchaseDAL.GetPurchasedExpenseById(purchCropId);
        }
        public string AddPurchaseCrop(Purchase purchase, List<Expense> expenses)
        {
            return _objPurchaseDAL.AddPurchaseCrop(purchase, expenses);
        }
        public int DeletePurchaseCrop(Purchase purchase)
        {
            return _objPurchaseDAL.DeletePurchaseCrop(purchase);
        }

        public async Task<int> UpdatePurchaseCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            var res=await _objPurchaseDAL.UpdatePurchaseCrop(purchase, connectionFactory);
            return res;
        }

    }
}
