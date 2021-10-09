using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Abstract
{
    public interface IArticleImageBLL
    {
        int CreateArticleImage(ArticleImage entity);
        int UpdateArticleImage(ArticleImage entity);
        int DeleteArticleImage(int id);
    }
}
