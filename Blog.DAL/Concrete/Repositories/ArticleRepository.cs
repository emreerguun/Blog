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
            entity.Date = DateTime.Now;
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

        public Article GetArticleByID(int id)
        {
            return context.Articles.Where(x => x.ArticleID == id).FirstOrDefault();
        }

        public List<Article> GetArticlesByCategoryID(int id)
        {
            return context.Articles.Where(x=>x.CategoryID==id).ToList();
        }

        public List<Article> GetArticlesByNumberOfClick()
        {
            return context.Articles.OrderByDescending(x => x.NumberOfClick).Take(10).ToList();
        }

        public List<Article> GetArticlesByUserID(int id)
        {
            return context.Articles.Where(x=>x.UserID==id).ToList();
        }

        public List<Article> GetLast10Articles()
        {
            return context.Articles.OrderByDescending(x => x.Date).Take(10).ToList();
        }

        public int UpdateArticle(Article entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges();
        }

        public int UpNumberOfClick(Article entity)
        {
            entity.NumberOfClick++;
            return context.SaveChanges();
        }
    }
}
