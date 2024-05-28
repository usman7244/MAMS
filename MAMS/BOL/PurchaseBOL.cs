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
        private List<CropAndBag> _bags;
        private DAL.CommonDAL _objCommonDAL;
        public PurchaseBOL()
        {
            _objPurchaseDAL = new PurchaseDAL();
            _bags = new List<CropAndBag>();
            _objCommonDAL = new DAL.CommonDAL();
        }
        public async Task<List<CustomerType>> GetCustomerType(string cusType, Guid branchId, Guid createdBy, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetCustomerType(cusType, branchId, createdBy, sqlConnectionFactory);
        }
        public async Task<List<CropAndBag>> GetBags(Guid branchId, Guid createdBy,string Type, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetBags(branchId, createdBy,Type, sqlConnectionFactory);
        }
        public async Task<CashHistory> GetCashHistory(Guid branchId, Guid createdBy, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetCashHistory(branchId, createdBy, sqlConnectionFactory);
        }
        public async Task<List<Purchase>> GetAllPurchasedCrop(Purchase purchase, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetAllPurchasedCrop(purchase, sqlConnectionFactory);
        }


        public async Task<Purchase> GetPurchasedCropById(int purchCropId, ISqlConnectionFactory connectionFactory)
        {
           var resul =await _objPurchaseDAL.GetPurchasedCropById(purchCropId, connectionFactory);
            return resul;
        }
        public async Task<List<Expense>> GetPurchasedExpenseById(int purchCropId, ISqlConnectionFactory connectionFactory)
        {
            var re=await _objPurchaseDAL.GetPurchasedExpenseById(purchCropId, connectionFactory);
            return re;
        }
        public async Task<string> AddPurchaseCrop(Purchase purchase, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            var result=await _objPurchaseDAL.AddPurchaseCrop(purchase, expenses, connectionFactory);
            return result;
        }
        public async Task<int> DeletePurchaseCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objPurchaseDAL.DeletePurchaseCrop(purchase, connectionFactory);
            return result;
        }


        public async Task<int> UpdatePurchaseCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            int affectedrow = 0;
            var res=await _objPurchaseDAL.UpdatePurchaseCrop(purchase, connectionFactory);
            if (affectedrow == 0)
            {

                if (decimal.TryParse(purchase.DiffCash, out decimal diffCash) && decimal.TryParse(purchase.TotalCropPrice.ToString(), out decimal totalCash))
                {
                    var diff = Convert.ToInt32(diffCash - totalCash);
                    if (diff < 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = Guid.Empty,
                            CashLost = diff.ToString().Replace("-", ""),

                        };


                        var re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, connectionFactory);
                        return re;
                    }
                    else if (diff > 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = Guid.Empty,
                            CashProfit = diff.ToString(),

                        };


                        var re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, connectionFactory);
                        return re;
                    }

                }
                else
                {

                    throw new ArgumentException("Invalid numeric value for DiffCash or TotalCash.");
                }

            }
            else
            {
                throw new ArgumentException("Invalid numeric value for DiffCash or TotalCash.");
            }
            return affectedrow;
        }

    }
}
