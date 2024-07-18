using BOL;
using DAL.Sql;
using MAMS.CustomFilters;
using MAMS.Models;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MAMS.Controllers
{

    [IdentityUser]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private CashHistory _cashHistory;
        private ISqlConnectionFactory _connectionFactory;
        private CommonBOL _objCommonBOL;
        public HomeController(ILogger<HomeController> logger, ISqlConnectionFactory connectionFactory)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;
            CashHistory _cashHistory = new CashHistory();
            _objCommonBOL = new CommonBOL();
        }
        [HttpGet]
        public async Task<IActionResult> Index(CashHistory From)
        {

            _cashHistory = new CashHistory();
            _cashHistory.BranchId = GetBranchId();
            if (From.FromDate == DateTime.MinValue && From.ToDate == DateTime.MinValue)
            {
                _cashHistory.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
                _cashHistory.ToDate = DateTime.Now;
            }
            else 
            {
                _cashHistory.FromDate = From.FromDate;
                _cashHistory.ToDate = From.ToDate;

            }
              List<CashHistory> cashHistoryList = await _objCommonBOL.GetFilterCashHistory(_cashHistory, _connectionFactory);

                return View(cashHistoryList);
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
