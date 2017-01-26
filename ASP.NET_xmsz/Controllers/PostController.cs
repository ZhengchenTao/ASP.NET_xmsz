using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biz;
using ASP.NET_xmsz.Models;

namespace ASP.NET_xmsz.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Posting(int forumsid)
        {
            ViewBag.url = Request.UrlReferrer;
            PostList Db = new PostList();
            Db.Forums = new GetForums().SelectForums();
            Db.CurrentForums = new GetForums().SelectForums(forumsid);
            return View("Posting", Db);
        }
        public ActionResult AddPost(int forumsid, string posttitle, string postcontent)
        {
            int userid;
            if (Session["userId"] == null)
            {
                return Content("log");
            }
            userid = (int)Session["userid"];
            Post p = new Post() { Title = posttitle, Content = postcontent, Forums_Id = forumsid, Users_Id = userid };
            int re = new GetPost().AddPost(p);
            if (re == 1)
            {
                var a = new GetPost().SelectLastPost(forumsid);
                var ps = new
                {
                    PostId = a.Id,
                    success = 1,
                };
                return Json(ps);
            }
            return JavaScript("alert('发表失败');");
        }
        public ActionResult ShowPost(int postid)
        {
            var url = Request.UrlReferrer;
            bool a = new GetPost().ClickPost(postid);
            ReplyPost Db = new ReplyPost();
            Db.Post = new GetPost().SelectPost(postid);
            Db.Reply = new GetReply().SelectReply(postid);
            ViewBag.url = url;
            return View("Post", Db);
        }
        [HttpPost]
        public ActionResult AddReply(int postid, string rcontent)
        {
            int userid;
            if (Session["userId"] == null)
            {
                return Content("log");
            }
            userid = (int)Session["userId"];
            Reply r = new Reply() { Post_Id = postid, Users_Id = userid, Content = rcontent };
            bool re = new GetReply().AddReply(r);

            ReplyPost Db = new ReplyPost();
            Db.Post = new GetPost().SelectPost(postid);
            Db.Reply = new GetReply().SelectReply(postid);
            if (re == false)
            {
                return JavaScript("alert('回复失败');");
            }
            return Content("success");
        }
    }
}