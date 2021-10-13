using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Blog.DAL.Abstract;
using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                users.Add(new UserDTO() { UserID=user.UserID,Name = user.Name, Surname = user.Surname, UserName = user.UserName });
            }
            return users;
        }

        public UserDTO GetUserByUserName(string username)
        {
            User user = repository.GetUserByUserName(username);
            UserDTO userDto = new UserDTO() { UserID=user.UserID,Name = user.Name, Surname = user.Surname, UserName = user.UserName };
            return userDto;
        }

        public UserDTO Login(UserDTO dto)
        {
            string pass = MD5_Encrypt(dto.Password);
            dto.Password = pass;
            User user = repository.GetUserByUserName(dto.UserName);
            if (user != null)
            {
                if (user.Password == dto.Password)
                {
                    dto.UserID = user.UserID;
                    dto.Name = user.Name;
                    dto.Surname = user.Surname;
                    return dto;
                }
                else return null;
            }
            else return null;
        }

        public int Register(UserDTO entity)
        {
            User user = new User() { Name = entity.Name, Surname = entity.Surname, UserName = entity.UserName, Password = entity.Password };
            string pass = MD5_Dencrypt(entity.Password);
            user.Password = pass;
            if (user != null)
            {
                user.UserRole = 1;
                return repository.Register(user);
            }
            else
            {
                return 0;
            }
        }

        public static string MD5_Encrypt(string str)
        {
            string output = string.Empty;
            using (MD5 md5 = MD5.Create())
            {
                byte[] md5_in = Encoding.UTF8.GetBytes(str);
                byte[] md5_out = md5.ComputeHash(md5_in);

                output = BitConverter.ToString(md5_out).ToLower();
                output = output.Replace("-", "");
            }
            return output;
        }

        public static string MD5_Dencrypt(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}
