using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MAMS.Controllers
{
    public class ErrorController : Controller
    {
    
        [Route("Error/{statuscode}")]
        public IActionResult HTTPStatusCodeHandler(int statuscode)
        {
            var statuscoderesult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrorMassege = "Sorry the resources not found ";
                    ViewBag.Path = statuscoderesult.OriginalPath;
                    ViewBag.Qs = statuscoderesult.OriginalQueryString;
                    break;

            }
            return View("Not found");
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionsDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionsDetails.Path;
            ViewBag.ExceptionMassege = exceptionsDetails.Error.Message;
            ViewBag.StackTrace = exceptionsDetails.Error.StackTrace;
            return View("Error");
        }
    }
}
