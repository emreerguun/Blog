using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Process.Controllers
{
    [Area("Process")]
    public class ProcessController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
