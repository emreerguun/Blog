using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Process.Controllers
{
    [Area("Process")]
    public class ArticleController : Controller
    {
        private IArticleBLL articleBLL;
        private readonly IWebHostEnvironment hostEnvironment;
        public ArticleController(IArticleBLL _articalBLL, IWebHostEnvironment _hostEnviroment)
        {
            articleBLL = _articalBLL;
            hostEnvironment = _hostEnviroment;
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyArticles(int userID) 
        {
            return View(articleBLL.GetArticlesByUserID(userID));
        }
        [HttpGet]
        [Authorize]
        public IActionResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateArticle(ArticalDTO articleDTO)
        {
            if (ModelState.IsValid)
            {
                if (articleDTO.ImageFile != null)
                {
                    string wwwRootPath = hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(articleDTO.ImageFile.FileName);
                    string extension = Path.GetExtension(articleDTO.ImageFile.FileName);
                    string imagePath = fileName + Guid.NewGuid() + extension;
                    articleDTO.ImageName = imagePath;
                    string path = Path.Combine(wwwRootPath + "/Images/ArticalImages/", imagePath);
                    var stream = new FileStream(path, FileMode.Create);
                    articleDTO.ImageFile.CopyToAsync(stream);
                    articleDTO.ImagePath = imagePath;
                }
                articleDTO.UserID = int.Parse(User.Claims.FirstOrDefault().Value);
                articleBLL.CreateArticle(articleDTO);
                Response.Redirect("MyArticles?userID=" + articleDTO.UserID);
                return View();
            }
            else return View(articleDTO);
        }
        [HttpGet]
        [Authorize]
        public IActionResult UpdateArticle(int articleID) 
        {
            ArticalDTO article=articleBLL.GetArticleByID(articleID);
            return View(article);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateArticle(ArticalDTO articleDTO)
        {
            if (articleDTO.ImageFile!=null)
            {
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(articleDTO.ImageFile.FileName);
                string extension = Path.GetExtension(articleDTO.ImageFile.FileName);
                string imagePath = fileName + Guid.NewGuid() + extension;
                articleDTO.ImageName = imagePath;
                string path = Path.Combine(wwwRootPath + "/Images/ArticalImages/", imagePath);
                var stream = new FileStream(path, FileMode.Create);
                articleDTO.ImageFile.CopyToAsync(stream);
            }
            articleDTO.UserID= int.Parse(User.Claims.FirstOrDefault().Value);
            int result= articleBLL.UpdateArticle(articleDTO);
            if (result==1)
            {
                Response.Redirect("MyArticles?userID="+ articleDTO.UserID);
                return View();
            }
            else
            {
                return View(articleDTO);
            }
            
        }

        public void DeleteArticle(int articleID)
        {
            int userID = int.Parse(User.Claims.FirstOrDefault().Value);
            int result=articleBLL.DeleteArticle(articleID);
           
            if (result == 1)
            {
                Response.Redirect("MyArticles?userID=" + userID);
            }
            //return View();
        }
    }
}
