using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz
{
    public class GetUsers
    {
        public Db Db = new Db();
        public bool Login(string username,string userpass)
        {
           Users user = Db.Users.SingleOrDefault(u => u.username == username && u.userpass == userpass);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<Users> SelectUsers()
        {
            return Db.Users.ToList();
        }
        public IList<Users> SelectUsers(int i)
        {
            var list = Db.Users.Where(u => u.Id == i).ToList();
            return list;
        }
        public Users SelectUser(int i)
        {
            return Db.Users.SingleOrDefault(u => u.Id == i);
        }
        public Users Login(Users us)
        {
            Users user = Db.Users.SingleOrDefault(b => b.username == us.username && b.userpass == us.userpass);
            return user;
        }
        public int AddUser(Users us)
        {
            IList<Users> use = Db.Users.Where(u => u.username == us.username).ToList();
            if (use.Count > 0)
            {
                return 2;
            }
            try
            {
                DateTime now = DateTime.Now;
                Users user = new Users() { username = us.username, userpass = us.userpass, regtime = now };
                Db.Users.Add(user);
                return Db.SaveChanges() > 0 ? 1 : 0;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        public bool UpdateUser(Users us)
        {
            try
            {
                Users up = Db.Users.SingleOrDefault(u => u.Id == us.Id);
                up.username = us.username;
                up.userpass = us.userpass;
                up.Role = us.Role;
                return Db.SaveChanges() > 0 ? true : false;
            }
            catch(Exception)
            {
                return false;
                throw;
            }

        }
        public bool DeleteUser(int userid)
        {
            try
            {
                Users us = Db.Users.SingleOrDefault(u => u.Id == userid);
                Db.Users.Remove(us);
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
