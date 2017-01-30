using System.Web.Mvc;
using Biz;
using ASP.NET_xmsz.Models;

namespace ASP.NET_xmsz.Controllers
{
    public class ForumsController : Controller
    {
        // GET: Forums
        public ActionResult Index()
        {
            ForumsList Db = new ForumsList();
            Db.Forums = new GetForums().SelectForums();
            return View("Forums", Db);
        }
    }
}