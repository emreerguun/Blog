using Blog.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Abstract
{
    public interface IUserBLL
    {
        int Register(UserDTO dto);
        UserDTO GetUserByUserName(string username);
        List<UserDTO> GetAllUser();
        UserDTO Login(UserDTO dto);
    }
}
