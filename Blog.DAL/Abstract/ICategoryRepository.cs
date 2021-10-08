using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Abstract
{
    public interface ICategoryRepository
    {
        int CreateCategory(Category entity);
        int UpdateCategory(Category entity,int id);
        int DeleteCategory(int id);
        List<Category> GetAllCategories();
    }
}
