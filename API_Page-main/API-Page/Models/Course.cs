using System;
using System.ComponentModel.DataAnnotations;

namespace API_Page.Models
{
    public class Course //课程表
    {
        public int Id { get; set; }//课程ID


        [Display(Name = "课程名称")]
        public string CourseName { get; set; }//课程名称

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime StartingTime { get; set; }//上课时间


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }//结束时间

        public int Professional_Id { get; set; }//专业ID


        public int CourseMajor { get; set; } //是否主修课（1是 2不是)



    }
}
