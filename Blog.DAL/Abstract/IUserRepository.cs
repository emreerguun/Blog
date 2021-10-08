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
        int Login(string username,string password);
        int Register(User entity);
        List<User> GetAllUsers();
        
    }
}
