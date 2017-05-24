using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biz;
using Biz.Entity;

namespace ASP.NET_xmsz.Models
{
    public class Personedit
    {
        public Users user { get; set; }
        public int parent { get; set; }
        public int city { get; set; }
    }
}