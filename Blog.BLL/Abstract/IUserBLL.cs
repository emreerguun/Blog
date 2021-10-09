using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Abstract
{
    public interface IUserBLL
    {
        int Register(User entity);
        User GetUserByUserName(string username);
        List<User> GetAllUser();
    }
}
