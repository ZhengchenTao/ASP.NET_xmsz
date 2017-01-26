using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biz;
using ASP.NET_xmsz.Models;

namespace ASP.NET_xmsz.Controllers
{
    public class LoginController : Controller
    {
        Jsonre re = new Jsonre();
        [HttpPost]
        public ActionResult Login(Users u, string remember)
        {
            /*Users u = new Users();
            u.username = username;
            u.userpass = userpass;*/
            if (Session["userId"] != null)
            {
                re.state = "Error";
                re.message = "您已登录";
                return Json(re);
            }
            Users user = new GetUsers().Login(u);
            if (user != null)
            {
                Session["userId"] = user.Id;
                Session["username"] = user.username;
                if (remember == "true")
                {
                    Response.Cookies["username"].Value = user.username;
                    Response.Cookies["userpass"].Value = user.userpass;
                }
                else
                {
                    Response.Cookies["username"].Value = null;
                    Response.Cookies["userpass"].Value = null;
                }
                re.state = "Error";
                re.message = "登录成功";
                return Json(re);
            }
            re.state = "Error";
            re.message = "登录失败 请检查用户名密码";
            return Json(re);
        }
        [HttpPost]
        public ActionResult Logout()
        {
            if (Session["userId"] != null && Session["username"] != null)
            {
                Session["userId"] = null;
                Session["username"] = null;
            }
            re.state = "Success";
            re.message = "退出成功";
            return Json(re);
        }
        [HttpPost]
        public ActionResult Register(string username, string userpass)
        {
            Users u = new Users() { username = username, userpass = userpass };
            var addnum = new GetUsers().AddUser(u);
            if (addnum == 1)
            {
                re.state = "Success";
                re.message = "注册成功";
                return Json(re);
            }
            else if(addnum==2)
            {
                re.state = "Error";
                re.message = "注册失败,已经有相同的用户名";
                return Json(re);
            }
            else
            {
                re.state = "Error";
                re.message = "注册失败,未知错误请联系管理员";
                return Json(re);
            }
        }
    }
}