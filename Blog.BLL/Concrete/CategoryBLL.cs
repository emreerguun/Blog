using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Concrete
{
    public class CategoryBLL : ICategoryBLL
    {
        private ICategoryRepository repository;
        public CategoryBLL(ICategoryRepository _repository)
        {
            repository = _repository;
        }
        public int CreateCategory(CategoryDTO entity)
        {
            return repository.CreateCategory(new Category() { Name=entity.Name });
        }

        public int DeleteCategory(int id)
        {
            return repository.DeleteCategory(id);
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<Category> categoryList= repository.GetAllCategories();
            List<CategoryDTO> categories = new List<CategoryDTO>();
            foreach (var category in categoryList)
            {
                categories.Add(new CategoryDTO() { CategoryID=category.CategoryID,Name=category.Name });
            }
            return categories;
        }

        public CategoryDTO GetCategoryByID(int id)
        {
            Category category=repository.GetCategoryByID(id);
            CategoryDTO categoryDTO = new CategoryDTO() { CategoryID=category.CategoryID, Name=category.Name };
            return categoryDTO;
        }

        public int UpdateCategory(CategoryDTO entity)
        {
            Category category = new Category() {  CategoryID=entity.CategoryID,Name = entity.Name };
            return repository.UpdateCategory(category);
        }
    }
}
