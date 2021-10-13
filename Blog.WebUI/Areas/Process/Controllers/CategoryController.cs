using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Process.Controllers
{
    [Area("Process")]
    public class CategoryController : Controller
    {
        ICategoryBLL categoryBLL;
        IArticleBLL articleBLL;
        public CategoryController(ICategoryBLL _categoryBLL, IArticleBLL _articleBLL)
        {
            categoryBLL = _categoryBLL;
            articleBLL = _articleBLL;
        }
        public IActionResult CategoryList()
        {
            return View(categoryBLL.GetAllCategories());
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                int result = categoryBLL.CreateCategory(category);
                if (result == 1)
                {
                    return RedirectToAction("CategoryList");
                }
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int categoryID)
        {
            CategoryDTO categoryDTO = categoryBLL.GetCategoryByID(categoryID);
            return View(categoryDTO);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryDTO category)
        {
            int result = categoryBLL.UpdateCategory(category);
            if (result == 1)
            {
                Response.Redirect("/Process/Category/CategoryList");
                return View();
            }
            else return View(category);
        }

        public void DeleteCategory(int categoryID)
        {
            List<ArticalDTO> articles=articleBLL.GetArticlesByCategoryID(categoryID);
            if (articles.Count==0)
            {
                categoryBLL.DeleteCategory(categoryID);
            }
            else
            {
                ViewBag.Error = "Bu Kategori'nin Makaleleri Mevcut Olduğu İçin Silinemez. Kategoriyi Sadece Düzenleyebilirsiniz.";
            }
            Response.Redirect("/Process/Category/CategoryList");
        }
    }
}
