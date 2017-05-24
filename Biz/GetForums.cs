using System;
using System.Collections.Generic;
using System.Linq;

namespace Biz
{
    public class GetForums
    {
        public Db Db = new Db();
        public IList<Forums> SelectForums()
        {
            var list = Db.Forums.Include("Post").ToList();
            return list;
        }
        public Forums SelectForum(int id)
        {
            return Db.Forums.Include("Post").SingleOrDefault(f => f.Id == id);
        }
        public IList<Forums> SelectForums(int id)
        {
            var list = Db.Forums.Include("Post").Where(a => a.Id == id).ToList();
            return list;
        }
        public bool UpdateForums(Forums f)
        {
            try
            {
                var fu = SelectForum(f.Id);
                fu.ForumsTitle = f.ForumsTitle;
                return Db.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool AddForums(string forumtitle)
        {
            try
            {
                Forums f = new Forums() { ForumsTitle = forumtitle };
                Db.Forums.Add(f);
                return Db.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteForums(int fid)
        {
            try
            {
                Forums fo = Db.Forums.SingleOrDefault(f => f.Id == fid);
                Db.Forums.Remove(fo);
                return Db.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
