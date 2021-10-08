using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Abstract;
using Blog.Entities.Entities;

namespace Blog.DAL.Concrete.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public int Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int Register(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
