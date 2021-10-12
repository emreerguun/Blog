using Blog.BLL.DTO;
using Blog.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Abstract
{
    public interface ICategoryBLL
    {
        int CreateCategory(CategoryDTO entity);
        int UpdateCategory(CategoryDTO entity);
        int DeleteCategory(int id);
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryByID(int id);
    }
}
