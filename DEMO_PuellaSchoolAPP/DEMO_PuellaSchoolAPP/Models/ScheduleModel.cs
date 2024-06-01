namespace DEMO_PuellaSchoolAPP.Models
{
    public class ScheduleModel
    {
        public int IdSchedule { get; set; }
        public string ScheduleInfo { get; set; }
        public DateTime ScheduleCreation { get; set; }
        public TimeSpan ScheduleStart { get; set; }
        public TimeSpan ScheduleEnd { get; set; }
        public DateTime ScheduleExpiration { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
    }
}
