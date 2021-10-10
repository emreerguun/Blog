﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Adınızı Giriniz"), MinLength(2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyadınızı Giriniz"), MinLength(2)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adınızı Giriniz"), MinLength(4)]
        public string UserName { get; set; }
        [Required, MinLength(6), MaxLength(10)]
        public string Password { get; set; }
    }
}