using Blog.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class HomeController : Controller
    {
        IArticleBLL articleBLL;
        public HomeController(IArticleBLL _iarticleBLL)
        {
            articleBLL = _iarticleBLL;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Articles()
        {
            return View(articleBLL.GetAllArticles());
        }
        [HttpGet]
        public IActionResult Article(int articleID)
        {
            UpArticleNumberOfClick(articleID);
            return View(articleBLL.GetArticleByID(articleID));
        }
        [HttpGet]
        public IActionResult ArticlesByCategory(int categoryID)
        {
            return View(articleBLL.GetArticlesByCategoryID(categoryID));
        }

        [HttpGet]
        public IActionResult Last10Articles()
        {
            return View(articleBLL.GetLast10Articles());
        }

        [HttpGet]
        public IActionResult Top10Articles()
        {
            return View(articleBLL.GetArticlesByNumberOfClick());
        }

        public void UpArticleNumberOfClick(int articleID)
        {
            articleBLL.UpNumberOfClick(articleID);
        }

    }
}
