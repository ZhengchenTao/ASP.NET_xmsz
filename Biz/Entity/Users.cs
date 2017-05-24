using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biz
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string userpass { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月 HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime regtime { get; set; }
        [DefaultValue(0)]
        public int Role { get; set; }
        [DefaultValue(0)]
        public int districtId { get; set; }
        [DefaultValue(0)]
        public int sex { get; set; }
        //经验值
        [DefaultValue(0)]
        public int exp { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月}", ApplyFormatInEditMode = true)]
        public DateTime birthday { get; set; }
        public string headportrait { get; set; }
        public string introduce { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月}", ApplyFormatInEditMode = true)]
        public DateTime lastLogTime { get; set; }
    }
}
