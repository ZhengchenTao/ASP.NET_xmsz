using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Entity
{
    public class District
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DefaultValue(0)]
        public int parent_id { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [Required]
        [DefaultValue(0)]
        public int sort { get; set; }
    }
}
