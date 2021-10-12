using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Process.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponent:ViewComponent
    {
        ICategoryBLL categoryBLL;
        public CategoryViewComponent(ICategoryBLL _categoryBLL)
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
