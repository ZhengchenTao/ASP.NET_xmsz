using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biz;
using ASP.NET_xmsz.Models;
using PagedList;

namespace ASP.NET_xmsz.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string postname, int forumsid = 1, int page = 1)
        {
            PostList Db = new PostList();
            Db.Forums = new GetForums().SelectForums();
            Db.Post = new GetPost().SearchPost(postname).OrderByDescending(p => p.CreateTime).ToPagedList(page, 10);
            Db.CurrentForums = new GetForums().SelectForums(forumsid);
            return View("../Post/PostSearch", Db);
        }
    }
}