using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using DAL.Sql;
using Microsoft.AspNetCore.Mvc;

namespace MAMS.CustomFilters
{
    public class IdentityUser : ActionFilterAttribute, IActionFilter
    {

        private BOL.UserBOL _objUserBOL;
        
 
        public IdentityUser()
        {
            _objUserBOL = new BOL.UserBOL();


        }
     
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
             
            if (!IsAuthenticated)
            { 
                context.Result = new RedirectToActionResult("Login", "Admin", null);
            } 
          //  base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            //if (IsAuthenticated)
            //{
                 
            //    context.Result = new RedirectToActionResult("Login", "Account", null);
            //}
        }
    }
}
