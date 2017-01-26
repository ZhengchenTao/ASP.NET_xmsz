using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biz;

namespace ASP.NET_xmsz.Models
{
    public class ReplyPost
    {
        public Post Post { get; set; }
        public IList<Reply> Reply { get; set; }
    }
}