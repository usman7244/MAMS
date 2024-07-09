using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BOL;
using DAL.Sql;
using System.Threading.Tasks;
using MAMS.CustomFilters;
using Microsoft.AspNetCore.Authorization;

namespace MAMS.Controllers
{
    
    [IdentityUser]
   
    public class CashHistoryController : BaseController
    {
        private ISqlConnectionFactory _connectionFactory;
        private CashHistory _cashHistory;
        
        private CommonBOL _objCommonBOL;

        public CashHistoryController(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            CashHistory _cashHistory = new CashHistory();
            _objCommonBOL = new CommonBOL();

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            _cashHistory = new CashHistory();
            _cashHistory.BranchId = GetBranchId();
            _cashHistory.CreatedBy = Guid.Empty;


            List<CashHistory> cashHistoryList = await _objCommonBOL.GetAllCashHistoryInfo(_cashHistory, _connectionFactory);

           


            return View(cashHistoryList);
        }


    }
}
