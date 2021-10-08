using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Abstract
{
    public interface IArticleImageRepository
    {
        int CreateArticleImage(ArticleImage entity);
        int UpdateArticleImage(ArticleImage entity,int id);
        int DeleteArticleImage(int id);
    }
}
