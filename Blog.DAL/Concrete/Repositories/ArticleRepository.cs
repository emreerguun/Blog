using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Concrete.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public int CreateArticle(Article entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByNumberOfClick()
        {
            throw new NotImplementedException();
        }

        public int UpdateArticle(Article entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
