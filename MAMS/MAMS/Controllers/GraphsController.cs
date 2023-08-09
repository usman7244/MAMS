using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
    public class GraphsController : Controller
    {
        public IActionResult UserSelectionGraph()
        {
            return View();
        }
    }
}
