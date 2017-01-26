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
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Forums_Id { get; set; }
        [Required]
        public int Users_Id { get; set; }
        [Required]
        public string Content { get; set; }
        [DefaultValue(0)]
        public int ClickNum { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月 HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }

        [ForeignKey("Forums_Id")]
        public Forums Forums { get; set; }
        [ForeignKey("Users_Id")]
        public Users Users { get; set; }
    }
}
