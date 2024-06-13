using BOL;
using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MAMS.Controllers
{
    public class UserController : Controller
    {
        private CommonBOL _objCommonBOL;
        private readonly ISqlConnectionFactory _connectionFactory;
        private User _user;
        private UserBOL _objUserBOL;
        public UserController(ISqlConnectionFactory connectionFactory)
        {
            _objCommonBOL = new CommonBOL();
            _objUserBOL = new UserBOL();
            _connectionFactory = connectionFactory;
            _user = new User();
        }
        public async Task<IActionResult> Index()
        {

            _user = new User();
            _user.ModifiedBy = Guid.Empty;
            _user.CreatedBy = Guid.Empty;


            List<User> user = await _objUserBOL.GetUserInfo(_connectionFactory);



            return View(user);
        }
        public async Task<IActionResult> UserAdd()
        {

            var Branches = await _objCommonBOL.GetBranches(_connectionFactory);
            var Roles = await _objCommonBOL.GetRole(_connectionFactory);
            ViewBag.Roles = Roles;
            ViewBag.Branches = Branches;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> UserAdd(User User)
        {
            int affectedRows = 0;
            if (User != null)
            {
                affectedRows = await _objUserBOL.UserAdd(User, _connectionFactory);
                if (affectedRows > 0)
                {
                    ViewBag.UserAddStatus = affectedRows;
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            _user = new User();
            _user.ModifiedBy = Guid.Empty;
            _user.UID = userId;

            var affectedRows = await _objUserBOL.DeleteUser(_user, _connectionFactory);
            //return Ok(affectedRows);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditUser(Guid Id)
        {
            var user = await _objUserBOL.GetSpecificUserInfo(Id, _connectionFactory);
            var Branches = await _objCommonBOL.GetBranches(_connectionFactory);
            var Roles = await _objCommonBOL.GetRole(_connectionFactory);
            ViewBag.Roles = Roles;
            ViewBag.Branches = Branches;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {

            int affectedRows = 0;
            if (user != null)
            {
                affectedRows = await _objUserBOL.EditUser(user, _connectionFactory);
                if (affectedRows > 0)
                {

                    //return RedirectToAction("Index");
                    ViewBag.UserEditStatus = affectedRows;

                }

            }

            return View();
        }
    }
}
