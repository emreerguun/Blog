using Blog.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Abstract
{
    public interface IArticleBLL
    {
        int CreateArticle(ArticalDTO entity);
        int UpdateArticle(ArticalDTO entity);
        int DeleteArticle(int id);
        List<ArticalDTO> GetAllArticles();
        List<ArticalDTO> GetArticlesByUserID(int id);
        List<ArticalDTO> GetArticlesByCategoryID(int id);
        List<ArticalDTO> GetLast10Articles();
        ArticalDTO GetArticleByID(int id);
        int UpNumberOfClick(int id);
        List<ArticalDTO> GetArticlesByNumberOfClick();
    }
}
