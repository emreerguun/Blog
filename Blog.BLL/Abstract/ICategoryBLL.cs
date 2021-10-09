using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Abstract
{
    public interface ICategoryBLL
    {
        int CreateCategory(Category entity);
        int UpdateCategory(Category entity);
        int DeleteCategory(int id);
        List<Category> GetAllCategories();
    }
}
