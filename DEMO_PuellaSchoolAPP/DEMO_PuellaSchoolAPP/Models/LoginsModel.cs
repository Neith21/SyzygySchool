namespace DEMO_PuellaSchoolAPP.Models
{
    public class LoginsModel
    {
        public int LoginId { get; set; }
        public string LoginUser { get; set; }
        public string LoginPassword { get; set;}
        public int TeacherId { get; set; }
        public int RoleId { get; set; }

        public TeachersModel Teachers { get; set; }
        public RolsModel Roles { get; set; }
    }
}
