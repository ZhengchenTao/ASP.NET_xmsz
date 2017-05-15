using System.Linq;
using System.Web.Mvc;
using Biz;
using ASP.NET_xmsz.Models;
using PagedList;

namespace ASP.NET_xmsz.Controllers
{
    public class PostListController : Controller
    {
        // GET: Post
        public ActionResult Index(int forumsid = 1, int page = 1)
        {
            PostList Db = new PostList();
            Db.Forums = new GetForums().SelectForums();
            Db.Post = new GetPost().SelectForumsPost(forumsid).OrderByDescending(p => p.CreateTime).ToPagedList(page, 10);
            Db.CurrentForums = new GetForums().SelectForums(forumsid);
            return View("PostList", Db);
        }
    }
}