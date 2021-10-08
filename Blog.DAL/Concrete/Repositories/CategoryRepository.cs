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
        public int CreateCategory(Category entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public int UpdateCategory(Category entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
