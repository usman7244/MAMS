using BOL;
using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private Company _company;
  
        private CompanyBOL _objCompanyBOL;
        public CompanyController(ISqlConnectionFactory connectionFactory)
        {
            _objCompanyBOL = new CompanyBOL();
            _connectionFactory = connectionFactory;
            _company = new Company();
        }
        public async Task<IActionResult> Index()
        {

            _company = new Company();
            _company.ModifiedBy = Guid.Empty;
           _company.CreatedBy = Guid.Empty;
          
          
            List<Company> company = await _objCompanyBOL.GetCompanyInfo( _connectionFactory);



            return View(company);
        }
        public IActionResult CompanyAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompanyAdd(Company company)
        {
            int affectedRows = 0;
            if (company != null)
            {
                affectedRows = await _objCompanyBOL.CompanyAdd(company, _connectionFactory);
                if (affectedRows > 0)
                {
                    ViewBag.CompanyAddStatus = affectedRows;
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCompany(Guid comId)
        {
            _company = new Company();
            _company.ModifiedBy = Guid.Empty;
            _company.UID = comId;

            var affectedRows = await _objCompanyBOL.DeleteCompany(_company, _connectionFactory);
            //return Ok(affectedRows);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditCompany(Guid Id)
        {
            var company = await _objCompanyBOL.GetSpecificCompanyInfo(Id, _connectionFactory);

            return View(company);
        }
        [HttpPost]
        public async Task<IActionResult> EditCompany(Company company)
        {

            int affectedRows = 0;
            if (company != null)
            {
                affectedRows = await _objCompanyBOL.EditCompany(company, _connectionFactory);
                if (affectedRows > 0)
                {

                    //return RedirectToAction("Index");
                    ViewBag.CompanyEditStatus = affectedRows;

                }

            }

            return View();
        }
    }
}
