using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biz;

namespace ASP.NET_xmsz.Models
{
    public class ForumsList
    {
        public IList<Forums> Forums { get; set; }
        public Post Post { get; set; }
    }
}