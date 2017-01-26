using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz
{
    public class GetReply
    {
        Db Db = new Db();
        public IList<Reply> SelectReply(int postid)
        {
            return Db.Reply.Include("Users").Where(r => r.Post_Id == postid).OrderBy(r => r.ReplyTime).ToList();
        }
        public bool AddReply(Reply r)
        {
            try
            {
                DateTime now = DateTime.Now;
                Reply reply = new Reply() { Post_Id = r.Post_Id, Users_Id = r.Users_Id, Content = r.Content, ReplyTime = now };
                Db.Reply.Add(reply);
                return Db.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public Reply SelectLastReply(int postid)
        {
            IList<Reply> re = Db.Reply.Include("Users").Where(r => r.Post_Id == postid).OrderByDescending(r=>r.ReplyTime).ToList();
            if (re.Count != 0)
            {
                var a = re.First();
                return a;
            }
            return null;
        }
    }
}
