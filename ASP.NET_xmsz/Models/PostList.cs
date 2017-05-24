using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biz;
using System.Data.Entity;
using PagedList;

namespace ASP.NET_xmsz.Models
{
    public class PostList
    {

        public IList<Forums> Forums { get; set; }
        public IPagedList<Post> Post { get; set; }
        public IList<Forums> CurrentForums { get; set; }
        public IList<Users> Users { get; set; }

    }
}