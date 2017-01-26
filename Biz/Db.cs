using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Biz
{
    public class Db : DbContext
    {
        public Db() : base("name=SQLConnectionString")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Forums> Forums { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Reply> Reply { get; set; }
    }
}
