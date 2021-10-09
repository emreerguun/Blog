using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Concrete.Repositories
{
    public class ArticleImageRepository : IArticleImageRepository
    {
        private readonly BlogDBContext context;
        public ArticleImageRepository(BlogDBContext _context)
        {
            context = _context;
        }

        public int CreateArticleImage(ArticleImage entity)
        {
            context.ArticleImages.Add(entity);
            return context.SaveChanges();
        }

        public int DeleteArticleImage(int id)
        {
            ArticleImage articleImage = context.ArticleImages.FirstOrDefault(x=>x.ArticleImageID==id);
            if (articleImage!=null)
            {
                context.ArticleImages.Remove(articleImage);
                return context.SaveChanges();
            }
            return 0;
        }

        public int UpdateArticleImage(ArticleImage entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
