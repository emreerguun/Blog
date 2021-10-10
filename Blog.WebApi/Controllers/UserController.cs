using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBLL userBLL;
        public UserController(IUserBLL _userBLL)
        {
            userBLL = _userBLL;
        }

        [HttpPost("register")]
        public int Register(UserDTO user) 
        {
            return userBLL.Register(user);
        }

        [HttpGet("getuserbyusername")]
        public UserDTO GetUserByUserName(string username) 
        {
            return userBLL.GetUserByUserName(username);
        }

        [HttpGet("getallusers")]
        public List<UserDTO> GetAllUser() 
        {
            return userBLL.GetAllUser(); 
        }
    }
}
