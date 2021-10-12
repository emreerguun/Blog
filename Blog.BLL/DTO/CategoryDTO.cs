using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DTO
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Kategori Adı Giriniz"), MinLength(2,ErrorMessage ="Kategori Adı En Az 2 Karakter Olmalıdır.")]
        public string Name { get; set; }
    }
}
