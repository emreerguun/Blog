using Blog.BLL.Abstract;
using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Concrete
{
    public class UserBLL : IUserBLL
    {
        private IUserRepository repository;
        public UserBLL(IUserRepository _repository)
        {
            repository = _repository;
        }
        public List<User> GetAllUser()
        {
            return repository.GetAllUser();
        }

        public User GetUserByUserName(string username)
        {
            return repository.GetUserByUserName(username);
        }

        public int Register(User entity)
        {
            User user = GetUserByUserName(entity.UserName);
            if (user == null)
            {
                return repository.Register(entity);
            }
            else
            {
                return 0;
            }
        }
    }
}
