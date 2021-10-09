using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Abstract
{
    public interface IUserRepository
    {
        int Register(User entity);
        User GetUserByUserName(string username);
        List<User> GetAllUser();
        
    }
}
