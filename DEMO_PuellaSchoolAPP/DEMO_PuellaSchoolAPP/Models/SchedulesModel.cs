namespace DEMO_PuellaSchoolAPP.Models
{
    public class SchedulesModel
    {
        public int ScheduleId { get; set; }
        public string ScheduleInfo { get; set; }
        public DateOnly ScheduleCreation {  get; set; }
        public TimeOnly ScheduleStart { get; set;}
        public TimeOnly ScheduleEnd { get; set;}
        public DateTime ScheduleExpiration { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }

        public SectionsModel? Sections { get; set; }
        public TeachersModel? Teachers { get; set; }
        public ClassesModel? Classes { get; set; }
    }
}
