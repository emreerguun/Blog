using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Blog.ViewComponents
{
    [ViewComponent(Name = "BlogCategories")]
    public class BlogCategoriesViewComponent : ViewComponent
    {
        ICategoryBLL categoryBLL;
        public BlogCategoriesViewComponent(ICategoryBLL _categoryBLL)
        {
            categoryBLL = _categoryBLL;
        }
        public IViewComponentResult Invoke()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            categories = categoryBLL.GetAllCategories();
            return View("Index", categories);
        }
    }
}
