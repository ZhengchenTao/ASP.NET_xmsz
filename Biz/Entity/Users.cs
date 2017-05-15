using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biz
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string userpass { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月 HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime regtime { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Role { get; set; }
        [Required]
        [DefaultValue(0)]
        public int districtId { get; set; }
        [Required]
        [DefaultValue(0)]
        public int sex { get; set; }
        //经验值
        [Required]
        [DefaultValue(0)]
        public int exp { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd月}", ApplyFormatInEditMode = true)]
        public DateTime birthday { get; set; }
        [Required]
        public string headportrait { get; set; }
        [Required]
        public string introduce { get; set; }
    }
}
