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
        private readonly BlogDBContext context;
        public UserRepository(BlogDBContext _context)
        {
            context = _context;
        }

        public List<User> GetAllUser()
        {
            return context.Users.ToList();
        }

        public User GetUserByUserName(string username)
        {
            return context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public int Register(User entity)
        {
            context.Users.Add(entity);
            return context.SaveChanges();
        }
    }
}
