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
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MAMS_Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;

namespace MAMS.Controllers
{

    public class AdminController : BaseController
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private LoginBOL _objLoginBOL;
        private CommonBOL _objCommonBOL;
        public AdminController(ISqlConnectionFactory connectionFactory)
        {
            _objCommonBOL = new CommonBOL();
            _objLoginBOL = new LoginBOL();
            _connectionFactory = connectionFactory;
      
        }
        [HttpGet]

        public async Task<IActionResult> Login()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                         new Claim(CustomClaimType.BranchId.ToString(), Credential.BranchUID.ToString()),
                         new Claim(CustomClaimType.BranchName.ToString(), Credential.BranchName.ToString()),

                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(UserClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    ModelState.Clear();
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
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
        [HttpPost] // Ensure it only accepts POST requests
        [ValidateAntiForgeryToken] // Ensure anti-forgery token validation
        public async Task<IActionResult> LogOut()
        {
            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Clear all cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            ModelState.Clear();
            return RedirectToAction("Login", "Admin");

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken] // Ensure request validation
        //public async Task<IActionResult> LogOut()
        //{
        //    // Sign out the user
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    // Clear authentication cookies and invalidate the session
        //    HttpContext.Session.Clear();
        //    foreach (var cookie in Request.Cookies.Keys)
        //    {
        //        Response.Cookies.Delete(cookie);
        //    }

        //    // Optionally clear the authentication cookie specifically if needed
        //    Response.Cookies.Append(
        //        ".AspNetCore.Cookies", "", new CookieOptions
        //        {
        //            Expires = DateTimeOffset.UtcNow.AddDays(-1)
        //        });

        //    ModelState.Clear();
        //    return RedirectToAction("Login", "Admin");
        //}


    }
}
