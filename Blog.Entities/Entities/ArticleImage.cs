using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Entities
{
    public class ArticleImage
    {
        public int ArticleImageID { get; set; }
        public string Path { get; set; }


        public virtual Article Article { get; set; }

    }
}
