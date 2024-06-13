using BOL;
using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private LoginBOL _objLoginBOL;
        public AdminController(ISqlConnectionFactory connectionFactory)
        {

            _objLoginBOL = new LoginBOL();
            _connectionFactory = connectionFactory;
      
        }
        public IActionResult Login()
        {
             
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            string Credential = await _objLoginBOL.Authenticate(Email, Password, _connectionFactory);

            if (Credential == "Success")
            {
                return RedirectToAction("Index", "Home");
            }
            else  
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View();
            }
             
        }

    }
}
