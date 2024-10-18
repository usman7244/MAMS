using MAMS_Models.Enums;
using MAMS_Models.Extenions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using MAMS_Models.Model;


namespace MAMS.Controllers
{
    public class BaseController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        protected Guid GetUserId()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.User.FindFirst(CustomClaimType.Userid.ToString())?.Value;
                return userId.ToGuid();
            }
            return Guid.Empty;
        }
        protected string GetRoleId()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var RoleId = HttpContext.User.FindFirst(CustomClaimType.RoleId.ToString())?.Value;
                return RoleId;
            }
            return null;
        }
        protected string GetEmail(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var Email = context.HttpContext.User.FindFirst(CustomClaimType.Email.ToString())?.Value;
                return Email;
            }
            return null;
        }
        protected string GetName(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var Name = context.HttpContext.User.FindFirst(CustomClaimType.Name.ToString())?.Value;
                return Name;
            }
            return null;
        }

        //protected string GetBranchId(ActionExecutingContext context)
        //{
        //    if (context.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        var BranchId = context.HttpContext.User.FindFirst(CustomClaimType.BranchId.ToString())?.Value;
        //        return BranchId;
        //    }
        //    return null;
        //}

        protected Guid GetBranchId()
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var branchId = HttpContext.User.FindFirst(CustomClaimType.BranchId.ToString())?.Value;
                return branchId.ToGuid();

            }
            return Guid.Empty;
        }

    }
}
