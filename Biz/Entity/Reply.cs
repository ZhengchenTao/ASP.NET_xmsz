using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Post_Id { get; set; }
        [Required]
        public int Users_Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月 HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReplyTime { get; set; }

        [ForeignKey("Users_Id")]
        public Users Users { get; set; }

    }
}
