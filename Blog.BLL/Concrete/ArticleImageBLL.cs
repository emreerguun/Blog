using Blog.BLL.Abstract;
using Blog.DAL.Concrete.Repositories;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Concrete
{
    public class ArticleImageBLL : IArticleImageBLL
    {
        private ArticleImageRepository repository;
        public ArticleImageBLL(ArticleImageRepository _repository)
        {
            repository = _repository;
        }
        public int CreateArticleImage(ArticleImage entity)
        {
            return repository.CreateArticleImage(entity);
        }

        public int DeleteArticleImage(int id)
        {
            return repository.DeleteArticleImage(id);
        }

        public int UpdateArticleImage(ArticleImage entity)
        {
            ArticleImage articleImage = new ArticleImage() { ArticleImageID=entity.ArticleImageID, Path=entity.Path };
            return repository.UpdateArticleImage(articleImage);
        }
    }
}
