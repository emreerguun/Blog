using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Abstract;
using Blog.Entities.Entities;

namespace Blog.DAL.Concrete.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDBContext context;
        public CategoryRepository(BlogDBContext _context)
        {
            context = _context;
        }
        public int CreateCategory(Category entity)
        {
            context.Categories.Add(entity);
            return context.SaveChanges();
        }

        public int DeleteCategory(int id)
        {
            Category category = context.Categories.FirstOrDefault(x=>x.CategoryID==id);
            if (category!=null)
            {
                context.Categories.Remove(category);
                return context.SaveChanges();
            }
            return 0;
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public int UpdateCategory(Category entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
