using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Blog.ViewComponents
{
    [ViewComponent(Name = "Top10Articles")]
    public class Top10ArticlesViewComponent : ViewComponent
    {
        IArticleBLL articleBLL;
        public Top10ArticlesViewComponent(IArticleBLL _articleBLL)
        {
            articleBLL = _articleBLL;
        }
        public IViewComponentResult Invoke()
        {
            List<ArticalDTO> articles;
            articles = articleBLL.GetArticlesByNumberOfClick();
            return View("Index", articles);
        }
    }
}
