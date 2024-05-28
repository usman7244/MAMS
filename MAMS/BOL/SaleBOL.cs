using DAL;
using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class SaleBOL
    {
        private Sale _sale;
        private List<Sale> _sales;
        private SaleDAL _objSaleDAL;

        public SaleBOL()
        {
            _sale = new Sale();
            _sales = new List<Sale>();
            _objSaleDAL = new SaleDAL();
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
        public async Task<int> UpdateSaleCrop(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var res = await _objSaleDAL.UpdateSaleCrop(sale, connectionFactory);
            return res;
        }
        public async Task<string> StockSaleAdd(Sale model, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objSaleDAL.StockSaleAdd(model, expenses, connectionFactory);
            return result;
        }

    }
}
