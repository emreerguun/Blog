using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Abstract
{
    public interface IArticleBLL
    {
        int CreateArticle(Article entity);
        int UpdateArticle(Article entity);
        int DeleteArticle(int id);
        List<Article> GetAllArticles();
        List<Article> GetArticlesByNumberOfClick();
    }
}
