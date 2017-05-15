using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz
{
    public class GetPost
    {
        Db Db = new Db();
        public IList<Post> showListByUser(int id)
        {
            return Db.Post.Include("Forums").Where(p => p.Users_Id == id).ToList();
        }
        public IList<Post> showListByUser(Users u)
        {
            return Db.Post.Include("Forums").Where(p => p.Users_Id == u.Id).ToList();
        }
        public IList<Post> SelectPost()
        {
            return Db.Post.Include("Users").Include("Forums").ToList();
        }
        public Post SelectPost(int id)
        {
            return Db.Post.Include("Forums").Include("Users").SingleOrDefault(p => p.Id == id);
        }
        public IList<Post> SelectForumsPost(int forumsid)
        {
            var list = Db.Post.Include("Users").Where(a => a.Forums_Id == forumsid).ToList();
            return list;
        }
        public int AddPost(Post po)
        {
            try
            {
                DateTime now = DateTime.Now;
                Post Post = new Post() { Title = po.Title, Forums_Id = po.Forums_Id, Users_Id = po.Users_Id, Content = po.Content, CreateTime = now, };
                Db.Post.Add(Post);
                return Db.SaveChanges() > 0 ? 1 : 0;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        public Post SelectLastPost(int forumsid)
        {
            IList<Post> re = Db.Post.Include("Users").Where(p => p.Forums_Id == forumsid).OrderByDescending(p => p.CreateTime).ToList();
            if (re.Count != 0)
            {
                var a = re.First();
                return a;
            }
            return null;
        }
        public bool ClickPost(int postid)
        {
            Post p = SelectPost(postid);
            p.ClickNum = p.ClickNum + 1;
            return Db.SaveChanges() > 0 ? true : false;
        }
        public bool UpdatePost(Post po)
        {
            try
            {
                Post p = Db.Post.SingleOrDefault(a => a.Id == po.Id);
                p.Title = po.Title;
                p.Content = po.Content;
                return Db.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public bool DeletePost(int pid)
        {
            try
            {
                Post po = Db.Post.SingleOrDefault(a => a.Id == pid);
                Db.Post.Remove(po);
                return Db.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public IList<Post> SearchPost(string postname)
        {
            return Db.Post.Include("Users").Where(a => a.Title.Contains(postname)).ToList();
        }

    }
}
