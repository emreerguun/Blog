using Blog.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class UserController : Controller
    {
        IUserBLL userBLL;
        public UserController(IUserBLL _userBLL)
        {
            userBLL = _userBLL;
        }
        public IActionResult GetAllUser()
        {
            return View(userBLL.GetAllUser());
        }
    }
}
