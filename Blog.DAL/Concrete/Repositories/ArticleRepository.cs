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
        private readonly BlogDBContext context;
        public ArticleRepository(BlogDBContext _context)
        {
            context = _context;
        }
        public int CreateArticle(Article entity)
        {
            context.Articles.Add(entity);
            return context.SaveChanges();
        }

        public int DeleteArticle(int id)
        {
            Article article = context.Articles.FirstOrDefault(x=>x.ArticleID==id);
            if (article!=null)
            {
                context.Articles.Remove(article);
                return context.SaveChanges();
            }
            return 0;
        }

        public List<Article> GetAllArticles()
        {
            return context.Articles.ToList();
        }

        public List<Article> GetArticlesByNumberOfClick()
        {
            return context.Articles.OrderByDescending(x => x.NumberOfClick).ToList();
        }

        public int UpdateArticle(Article entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
