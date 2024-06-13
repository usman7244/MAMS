using BOL;
using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MAMS.Controllers
{
    public class BranchController : Controller
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private Branch _branch;
        private CommonBOL _objCommonBOL;
        private BranchBOL _objBranchBOL;
        private Company _objCompany;
        public BranchController(ISqlConnectionFactory connectionFactory)
        {
            _objCommonBOL= new CommonBOL();
              _objBranchBOL = new BranchBOL();
            _connectionFactory = connectionFactory;
            _branch = new Branch();
        }
        public async Task<IActionResult> Index()
        {

            _branch = new Branch();
            _branch.ModifiedBy = Guid.Empty;
            _branch.CreatedBy = Guid.Empty;


            List<Branch> branch = await _objBranchBOL.GetBranchInfo(_connectionFactory);



            return View(branch);
        }
        public async Task<IActionResult> BranchAdd()
        {
         
            var companies = await _objCommonBOL.GetCompanies( _connectionFactory);

            ViewBag.Companies = companies;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BranchAdd(Branch branch)
        {
            int affectedRows = 0;
            if (branch != null)
            {
                affectedRows = await _objBranchBOL.BranchAdd(branch, _connectionFactory);
                if (affectedRows > 0)
                {
                    ViewBag.BranchAddStatus = affectedRows;
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBranch(Guid brhId)
        {
            _branch = new Branch();
            _branch.ModifiedBy = Guid.Empty;
            _branch.UID = brhId;

            var affectedRows = await _objBranchBOL.DeleteBranch(_branch, _connectionFactory);
            //return Ok(affectedRows);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditBranch(Guid Id)
        {
            var branch = await _objBranchBOL.GetSpecificBranchInfo(Id, _connectionFactory);
            var companies = await _objCommonBOL.GetCompanies(_connectionFactory);
            ViewBag.Companies = companies;
            return View(branch);
        }
        [HttpPost]
        public async Task<IActionResult> EditBranch(Branch branch)
        {

            int affectedRows = 0;
            if (branch != null)
            {
                affectedRows = await _objBranchBOL.EditBranch(branch, _connectionFactory);
                if (affectedRows > 0)
                {

                    //return RedirectToAction("Index");
                    ViewBag.BranchEditStatus = affectedRows;

                }

            }

            return View();
        }
         


    }
}
