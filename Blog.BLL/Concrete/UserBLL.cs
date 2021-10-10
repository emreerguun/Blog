using Blog.BLL.Abstract;
using Blog.BLL.DTO;
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
        public List<UserDTO> GetAllUser()
        {
            List<User> allUser = repository.GetAllUser();
            List<UserDTO> users = new List<UserDTO>();
            foreach (var user in allUser)
            {
                users.Add(new UserDTO() { Name=user.Name, Surname=user.Surname, UserName=user.UserName });
            }
            return users;
        }

        public UserDTO GetUserByUserName(string username)
        {
            User user=repository.GetUserByUserName(username);
            UserDTO userDto = new UserDTO() { Name=user.Name, Surname=user.Surname, UserName=user.UserName };
            return userDto;
        }

        public int Register(UserDTO entity)
        {
            User user = new User() {  Name=entity.Name, Surname=entity.Surname,UserName=entity.UserName, Password=entity.Password };
            if (user == null)
            {
                user.UserRole = 2;
                return repository.Register(user);
            }
            else
            {
                return 0;
            }
        }
    }
}
