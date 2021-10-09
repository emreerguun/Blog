using Blog.BLL.Abstract;
using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Concrete
{
    class CategoryBLL : ICategoryBLL
    {
        private ICategoryRepository repository;
        public CategoryBLL(ICategoryRepository _repository)
        {
            repository = _repository;
        }
        public int CreateCategory(Category entity)
        {
            return repository.CreateCategory(entity);
        }

        public int DeleteCategory(int id)
        {
            return repository.DeleteCategory(id);
        }

        public List<Category> GetAllCategories()
        {
            return repository.GetAllCategories();
        }

        public int UpdateCategory(Category entity)
        {
            Category category = new Category() {  CategoryID=entity.CategoryID,Name = entity.Name };
            return repository.UpdateCategory(category);
        }
    }
}
