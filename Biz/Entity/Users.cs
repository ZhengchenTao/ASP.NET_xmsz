using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string userpass { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月 HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime regtime { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Role { get; set; }

    }
}
