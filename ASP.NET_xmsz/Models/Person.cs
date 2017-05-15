using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biz;
using PagedList;

namespace ASP.NET_xmsz.Models
{
    public class Person
    {
        public Users user { get; set; }
        public IPagedList<Post> post { get; set; }
        public IPagedList<Reply> reply { get; set; }
    }
}