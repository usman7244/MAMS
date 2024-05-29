using DAL;
using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace BOL
{
    public class SaleBOL
    {
        private Sale _sale;
        private List<Sale> _sales;
        private SaleDAL _objSaleDAL;
        private DAL.CommonDAL _objCommonDAL;
        public SaleBOL()
        {
            _sale = new Sale();
            _sales = new List<Sale>();
            _objSaleDAL = new SaleDAL();
            _objCommonDAL = new DAL.CommonDAL();
        }
        public async Task<int> Update(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var res = await _objSaleDAL.Update(sale, connectionFactory);
            return res;
        }
        public async Task<int> Insert(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var res = await _objSaleDAL.Insert(sale, connectionFactory);
            return res;
        }
        public async Task<int> Delete(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var res = await _objSaleDAL.Delete(sale, connectionFactory);
            return res;
        }
        public async Task<Sale> GetById(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            _sale = new Sale();
            _sale = await _objSaleDAL.GetById(sale, connectionFactory);
            return _sale;
        }

        public async Task<List<Sale>> GetAllSaleCrop(Sale sale, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objSaleDAL.GetAllSaleCrop(sale, sqlConnectionFactory);
        }
        public async Task<string> SaleCropAdd(Sale sale, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objSaleDAL.SaleCropAdd(sale, expenses, connectionFactory);
            return result;
        }
        public async Task<int> DeleteSaleCrop(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objSaleDAL.DeleteSaleCrop(sale, connectionFactory);
            return result;
        }
        public async Task<Sale> GetSaleCropById(int Id, ISqlConnectionFactory connectionFactory)
        {
            var resul = await _objSaleDAL.GetSaleCropById(Id, connectionFactory);
            return resul;
        }
        public async Task<List<Expense>> GetSaleExpenseById(int Id, ISqlConnectionFactory connectionFactory)
        {
            var re = await _objSaleDAL.GetSaleExpenseById(Id, connectionFactory);
            return re;
        }
        public async Task<string> UpdateSaleCrop(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            String affectedrow = null;
             await _objSaleDAL.UpdateSaleCrop(sale, connectionFactory);
            if (affectedrow == null)
            {

                if (decimal.TryParse(sale.DiffCash, out decimal diffCash) && decimal.TryParse(sale.TotalCropPrice.ToString(), out decimal totalCash))
                {
                    var diff = Convert.ToInt32(totalCash - diffCash);
                    if (diff < 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = Guid.Empty,
                            CashLost = diff.ToString().Replace("-", ""),
                            Details = EnumExtension.GetDisplayName(ExpenseType.Sale),

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
                            Details = EnumExtension.GetDisplayName(ExpenseType.Sale),

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
        public async Task<string> StockSaleAdd(Sale model, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objSaleDAL.StockSaleAdd(model, expenses, connectionFactory);
            return result;
        }

    }
}
