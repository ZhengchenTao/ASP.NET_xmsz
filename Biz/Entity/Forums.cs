using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biz
{
    public class Forums
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ForumsTitle { get; set; }
        public IList<Post> Post { get; set; }
    }
}
