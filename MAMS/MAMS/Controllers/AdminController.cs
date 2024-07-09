using BOL;
using DAL.Sql;
 
using MAMS_Models.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MAMS_Models.Enums;

namespace MAMS.Controllers
{
 
    public class AdminController : BaseController
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private LoginBOL _objLoginBOL;
        private CommonBOL _objCommonBOL;
        public AdminController(ISqlConnectionFactory connectionFactory)
        {
            _objCommonBOL= new CommonBOL();
            _objLoginBOL = new LoginBOL();
            _connectionFactory = connectionFactory;
      
        }
        [HttpGet]
        public IActionResult Login()
        {
             
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                User Credential = await _objLoginBOL.Authenticate(user, _connectionFactory);

                if (Credential.Status == "Success")
                {
 
                    var UserClaims = new[]
                    {

                         new Claim(CustomClaimType.Email.ToString(), Credential.Email),
                         new Claim(CustomClaimType.Fullname.ToString(),Credential.Name),
                         new Claim(CustomClaimType.Userid.ToString(), Credential.UID.ToString()),
                         new Claim(CustomClaimType.RoleId.ToString(), Credential.RoleID.ToString()),
                         new Claim(CustomClaimType.BranchId.ToString(), Credential.BranchUID.ToString())

                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(UserClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");


                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View();
            }
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return Redirect("/Admin/Login");
        }

       




    }
}
