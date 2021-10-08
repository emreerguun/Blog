using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Kategori Adı Giriniz"),MinLength(2)]
        public string Name { get; set; }

        public virtual Article Article { get; set; }
    }
}
