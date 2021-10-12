using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Blog.WebUI.Areas.Process.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.WebUI.Areas.Process.Controllers
{
    [Area("Process")]
    public class UserController : Controller
    {
        IUserBLL userBLL;
        public UserController(IUserBLL _userBLL)
        {
            userBLL = _userBLL;
        }
        public IActionResult Login()
        {
            if (User.Identity.Name != null)
            {
                Response.Redirect("/Process/Process/Index");
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(UserDTO userDTO)
        {
            string pass = MD5_Encrypt(userDTO.Password);
            userDTO.Password = pass;
            UserDTO user = userBLL.Login(userDTO);
            if (user != null)
            {
                AddCookie(user);
                Response.Redirect("/Process/Process/Index");
                return View();
            }
            else
            {
                ViewBag.Error = "Kullanıcı Adı ve Şifrenizi Kontrol Ediniz.";
                return View(userDTO);
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                string pass = MD5_Dencrypt(userDTO.Password);
                userDTO.Password = pass;
                int result = userBLL.Register(userDTO);
                if (result == 1)
                {
                    UserDTO user = userBLL.GetUserByUserName(userDTO.UserName);
                    AddCookie(user);
                    Response.Redirect("/Process/Process/Index");
                    return View();
                }
                else
                {
                    return View(userDTO);
                }
            }
            else
            {
                return View(userDTO);
            }
        }
        public void AddCookie(UserDTO userDTO)
        {
            List<Claim> userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userDTO.UserID.ToString()));
            userClaims.Add(new Claim(ClaimTypes.Name, userDTO.UserName));
            userClaims.Add(new Claim(ClaimTypes.GivenName, userDTO.Name));
            userClaims.Add(new Claim(ClaimTypes.Surname, userDTO.Surname));
            var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
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
