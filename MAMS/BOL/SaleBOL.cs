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
        public async Task<List<Sale>> GetAll(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            _sales=new List<Sale>();
            _sales = await _objSaleDAL.GetAll(sale, connectionFactory);
            return _sales;
        }
        
    }
}
