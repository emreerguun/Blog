using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Adınızı Giriniz"), MinLength(2,ErrorMessage ="Adınız 2 Karakterden Fazla Olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyadınızı Giriniz"), MinLength(2, ErrorMessage = "Soyadınız 2 Karakterden Fazla Olmalıdır.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adınızı Giriniz"), MinLength(4,ErrorMessage ="Kullanıcı Adınız 4 Karakterden Fazla Olmalıdır."),MaxLength(12,ErrorMessage ="Kullanıcı Adınız 12 Karakterden Az Olmalıdır.")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifrenizi Giriniz."), MinLength(4,ErrorMessage ="Şifreniz 4 Karakterden Fazla Olmalıdır."), MaxLength(8,ErrorMessage ="Şifreniz 8 Karakterden Az Olmalıdır.")]
        public string Password { get; set; }
    }
}
