using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Concrete
{
    public class ArticleBLL : IArticleBLL
    {
        private readonly IArticleRepository repository;
        private readonly ICategoryRepository categoryRepository;
        public ArticleBLL(IArticleRepository _repository, ICategoryRepository _categoryRepository)
        {
            repository = _repository;
            categoryRepository = _categoryRepository;
        }
        public int CreateArticle(ArticalDTO dto)
        {
            Article article = new Article() { Title=dto.Title, Description=dto.Description, Content=dto.Content, ImagePath=dto.ImagePath, CategoryID=dto.CategoryID,UserID=dto.UserID,};
            return repository.CreateArticle(article);
        }

        public int DeleteArticle(int id)
        {
            return repository.DeleteArticle(id);
        }

        public List<ArticalDTO> GetAllArticles()
        {
            List<Article> articleList = repository.GetAllArticles();
            List<ArticalDTO> articles = new List<ArticalDTO>();
           
            foreach (var article in articleList)
            {
                Category category = categoryRepository.GetCategoryByID(article.CategoryID);
                articles.Add(new ArticalDTO() { ArticleID=article.ArticleID, Title=article.Title, Content=article.Content, Description=article.Description, NumberOfClick=article.NumberOfClick,CategoryName=category.Name, CategoryID=article.CategoryID,ImagePath=article.ImagePath });
            }
            return articles;
        }

        public ArticalDTO GetArticleByID(int id)
        {
            Article article=repository.GetArticleByID(id);
            Category category = categoryRepository.GetCategoryByID(article.CategoryID);
            ArticalDTO articleDTO = new ArticalDTO() { ArticleID=article.ArticleID, Title=article.Title, Description=article.Description, Content=article.Content, ImagePath=article.ImagePath, UserID=article.UserID, CategoryID=article.CategoryID,CategoryName=category.Name };
            return articleDTO;
        }

        public List<ArticalDTO> GetArticlesByCategoryID(int id)
        {
            List<Article> articleList = repository.GetArticlesByCategoryID(id);
            List<ArticalDTO> articles = new List<ArticalDTO>();
            foreach (var article in articleList)
            {
                Category category = categoryRepository.GetCategoryByID(article.CategoryID);
                articles.Add(new ArticalDTO() { ArticleID = article.ArticleID, Title = article.Title, Content = article.Content, Description = article.Description, NumberOfClick = article.NumberOfClick, CategoryName = category.Name, CategoryID = article.CategoryID, ImagePath = article.ImagePath });
            }
            return articles;
        }

        public List<ArticalDTO> GetArticlesByNumberOfClick()
        {
            List<Article> articleList = repository.GetArticlesByNumberOfClick();
            List<ArticalDTO> articles = new List<ArticalDTO>();
            foreach (var article in articleList)
            {
                articles.Add(new ArticalDTO() { ArticleID = article.ArticleID, Title = article.Title, Content = article.Content, Description = article.Description, NumberOfClick = article.NumberOfClick, CategoryID = article.CategoryID });
            }
            return articles;
        }

        public List<ArticalDTO> GetArticlesByUserID(int id)
        {
            List<Article> articleList = repository.GetArticlesByUserID(id);
            List<ArticalDTO> articles = new List<ArticalDTO>();
            foreach (var article in articleList)
            {
                articles.Add(new ArticalDTO() { ArticleID = article.ArticleID, Title = article.Title, Content = article.Content, Description = article.Description, NumberOfClick = article.NumberOfClick, CategoryID = article.CategoryID , ImagePath=article.ImagePath});
            }
            return articles;
        }

        public List<ArticalDTO> GetLast10Articles()
        {
           List<Article> articleList = repository.GetLast10Articles();
            List<ArticalDTO> articles = new List<ArticalDTO>();
            foreach (var article in articleList)
            {
                Category category = categoryRepository.GetCategoryByID(article.CategoryID);
                articles.Add(new ArticalDTO() { ArticleID = article.ArticleID, Title = article.Title, Content = article.Content, Description = article.Description, NumberOfClick = article.NumberOfClick, CategoryName = category.Name, CategoryID = article.CategoryID, ImagePath = article.ImagePath });
            }
            return articles;
        }

        public int UpdateArticle(ArticalDTO entity)
        {
            Article article;
            if (entity.ImageName!=null)
            {
                article = new Article() { ArticleID=entity.ArticleID,Title = entity.Title, Description = entity.Description, Content = entity.Content, CategoryID = entity.CategoryID, ImagePath=entity.ImageName,UserID=entity.UserID };
            }
            else
            {
                article = new Article() { ArticleID = entity.ArticleID, Title = entity.Title, Description = entity.Description, Content = entity.Content, CategoryID = entity.CategoryID,UserID=entity.UserID,ImagePath=entity.ImagePath };
               
            }
            return repository.UpdateArticle(article);
        }
    }
}
