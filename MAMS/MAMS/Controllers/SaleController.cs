using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BOL;
using DAL.Sql;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
    public class SaleController : Controller
    {
        private Sale _sale;
        private List<Sale> _saleList;
        private SaleBOL _objSALEBOL;

        private readonly ISqlConnectionFactory _connectionFactory;
        public SaleController(ISqlConnectionFactory connectionFactory)
        {
            _objSALEBOL = new SaleBOL();
            _sale = new Sale();
            _saleList = new List<Sale>();
            _connectionFactory = connectionFactory;
        }
        public async Task<IActionResult> Index()
        {
            _saleList = new List<Sale>();
            _sale = new Sale();

            _sale.BranchId = Guid.Empty;
            _sale.CreatedBy = Guid.Empty;

            _saleList =await _objSALEBOL.GetAll(_sale, _connectionFactory);
            return View(_saleList);
        }
        public async Task<IActionResult> Index(int ID)
        {
            _saleList = new List<Sale>();
            _sale = new Sale();
            
            _sale.UID = ID; 
            _sale.BranchId = Guid.Empty;
            _sale.CreatedBy = Guid.Empty;

            var sale = await _objSALEBOL.GetById(_sale, _connectionFactory);
            _saleList.Add(sale);
            return View(_saleList);
        }
    }
}
