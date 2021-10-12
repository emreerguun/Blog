using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Abstract
{
    public interface IArticleRepository
    {
        int CreateArticle(Article entity);
        int UpdateArticle(Article entity);
        int DeleteArticle(int id);
        List<Article> GetAllArticles();
        List<Article> GetArticlesByUserID(int id);
        List<Article> GetArticlesByCategoryID(int id);
        List<Article> GetLast10Articles();
        Article GetArticleByID(int id);
        List<Article> GetArticlesByNumberOfClick();
    }
}
