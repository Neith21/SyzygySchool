namespace DEMO_PuellaSchoolAPP.Models
{
    public class LoginModel
    {
        public int LoginId { get; set; }
        public string LoginUser { get; set; }
        public string LoginPassword { get; set; }
        public int TeacherId { get; set; }
        public int RoleId { get; set; }

        public RolesModel Roles { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}
