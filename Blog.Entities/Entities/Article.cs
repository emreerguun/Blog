using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Entities
{
    public class Article
    {
        public Article()
        {
            Categories = new HashSet<Category>();
        }
        public int ArticleID { get; set; }
        [Required(ErrorMessage = "Makale Başlığı Giriniz"), MinLength(5), MaxLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Makale Açıklaması Giriniz"), MinLength(5)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Makale İçeriği Giriniz")]
        public string Content { get; set; }
        public int NumberOfClick { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }

        public int CategoryID { get; set; }
        public int UserID { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual User User { get; set; }
    }
}
