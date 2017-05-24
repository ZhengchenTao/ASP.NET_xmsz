using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biz;
using PagedList;
using ASP.NET_xmsz.Models;

namespace ASP.NET_xmsz.Controllers
{
    public class AdminController : Controller
    {
        Jsonre re = new Jsonre();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowLogin()
        {
            return View("AdminLogin");
        }
        [HttpPost]
        public ActionResult AdminLogin(string username, string userpass)
        {
            Users u = new Users();
            u.username = username;
            u.userpass = userpass;
            if (Session["admin"] != null)
            {
                re.state = "Success";
                re.message = "您已登录";
                return Json(re);
            }
            Users user = new GetUsers().Login(u);
            if (user != null && user.Role == 2)
            {
                Session["admin"] = user.username;
                re.state = "Success";
                re.message = "登录成功";
                return Json(re);
            }
            re.state = "Error";
            re.message = "登录失败 请检查用户名密码或无管理员权限";
            return Json(re);
        }
        public ActionResult AdminLogout()
        {
            Session["admin"] = null;
            re.state = "Success";
            re.message = "已退出";
            return Json(re);
        }
        public ActionResult UserManage(int page = 1)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var re = new GetUsers().SelectUsers().OrderBy(u => u.Id).ToPagedList(page, 10);
            return View("UserManage", re);
        }
        public ActionResult UserUpdate(int userid, string username, string userpass, int role)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Users us = new GetUsers().SelectUser(userid);
            us.username = username;
            us.userpass = userpass;
            us.Role = role;
            bool st = new GetUsers().UpdateUser(us);
            if (st == true)
            {
                re.state = "Success";
                re.message = "修改成功";
            }
            else
            {
                re.state = "Error";
                re.message = "修改失败";
            }
            return Json(re);
        }
        public ActionResult UserDelete(int userid)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            bool de = new GetUsers().DeleteUser(userid);
            if (de == true)
            {
                re.state = "Success";
                re.message = "删除成功";
            }
            else
            {
                re.state = "Error";
                re.message = "删除失败";
            }
            return Json(re);
        }
        public ActionResult ForumManage(int page = 1)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var re = new GetForums().SelectForums().OrderBy(f => f.Id).ToPagedList(page, 10);
            return View("ForumManage", re);
        }
        public ActionResult ForumUpdate(int forumid, string forumstitle)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Forums f = new Forums() { Id = forumid, ForumsTitle = forumstitle };
            Jsonre re = new Jsonre();
            bool uf = new GetForums().UpdateForums(f);
            if (uf == true)
            {
                re.state = "Success";
                re.message = "更新成功";
            }
            else
            {
                re.state = "Error";
                re.message = "更新失败";
            }
            return Json(re);
        }
        public ActionResult ForumAdd(string forumtitle)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            bool af = new GetForums().AddForums(forumtitle);
            if (af == true)
            {
                re.state = "Success";
                re.message = "添加成功";
            }
            else
            {
                re.state = "Error";
                re.message = "添加失败";
            }
            return Json(re);
        }
        public ActionResult ForumDelete(int fid)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            bool af = new GetForums().DeleteForums(fid);
            if (af == true)
            {
                re.state = "Success";
                re.message = "删除成功";
            }
            else
            {
                re.state = "Error";
                re.message = "删除失败";
            }
            return Json(re);
        }
        public ActionResult PostManage(int page = 1)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var re = new GetPost().SelectPost().OrderBy(p => p.Id).ToPagedList(page, 10);
            return View("PostManage", re);
        }
        public ActionResult PostUpdate(int pid, string title, string content)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Post po = new GetPost().SelectPost(pid);
            po.Title = title;
            po.Content = content;
            bool st = new GetPost().UpdatePost(po);
            if (st == true)
            {
                re.state = "Success";
                re.message = "修改成功";
            }
            else
            {
                re.state = "Error";
                re.message = "修改失败";
            }
            return Json(re);
        }
        public ActionResult PostDelete(int pid)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            bool de = new GetPost().DeletePost(pid);
            if (de == true)
            {
                re.state = "Success";
                re.message = "删除成功";
            }
            else
            {
                re.state = "Error";
                re.message = "删除失败";
            }
            return Json(re);
        }
    }
}