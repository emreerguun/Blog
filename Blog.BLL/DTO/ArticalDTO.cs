using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DTO
{
    public class ArticalDTO
    {
        public int ArticleID { get; set; }
        [Required(ErrorMessage = "Makale Başlığı Giriniz"), MinLength(5, ErrorMessage = "Makale Başlığı En Az 5 Karakter İçermelidir."), MaxLength(50, ErrorMessage = "Makale Başlığı En Fazla 50 Karakter İçermelidir.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Makale Açıklaması Giriniz"), MinLength(5, ErrorMessage = "Makale Açıklaması En Az 5 Karakter İçermelidir.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Makale İçeriği Giriniz")]
        public string Content { get; set; }
        public int NumberOfClick { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }

    }
}
