using System.ComponentModel.DataAnnotations;

namespace API_Page.Models
{
    public class User //学生跟老师表
    {
        public int Id { get; set; }


        [Display(Name = "老师用户名")]
        public string UserName { get; set; }


        [Display(Name = "老师名字")]
        public string InstructorName { get; set; }


        [Display(Name = "系部ID")]
        public int ProfessionalId { get; set; }


        [Display(Name = "学生班级")]
        public string StudentClass { get; set; }


        [Display(Name = "学生姓名")]
        public string StudentName { get; set; }


        [Display(Name = "学号")]
        public string StudentId { get; set; }


        [Display(Name = "密码")]
        public string Password { get; set; }


        [Display(Name = "角色")]
        public int Role { get; set; }
    }
}
