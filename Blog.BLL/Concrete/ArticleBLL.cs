using Blog.BLL.Abstract;
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
        private IArticleRepository repository;
        public ArticleBLL(IArticleRepository _repository)
        {
            repository = _repository;
        }
        public int CreateArticle(Article entity)
        {
            return repository.CreateArticle(entity);
        }

        public int DeleteArticle(int id)
        {
            return repository.DeleteArticle(id);
        }

        public List<Article> GetAllArticles()
        {
            return repository.GetAllArticles();
        }

        public List<Article> GetArticlesByNumberOfClick()
        {
            return repository.GetArticlesByNumberOfClick();
        }

        public int UpdateArticle(Article entity)
        {
            Article article = new Article() { ArticleID=entity.ArticleID, Title=entity.Title, Description=entity.Description, Content= entity.Content, NumberOfClick= entity.NumberOfClick, CategoryID= entity.CategoryID };
            return repository.UpdateArticle(article);
        }
    }
}
