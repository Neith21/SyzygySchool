using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Schedules
{
    public interface IScheduleRepository
    {
        Task AddAsync(ScheduleModel schedule);
        Task DeleteAsync(int id);
        Task EditAsync(ScheduleModel schedule);
        Task<IEnumerable<ScheduleModel>> GetAllAsync();
        Task<IEnumerable<ClassModel>> GetAllClassAsync();
        Task<IEnumerable<SubjectModel>> GetAllSubjectAsync();
        Task<IEnumerable<TeacherModel>> GetAllTeacherAsync();
        Task<ScheduleModel?> GetByIdAsync(int id);
    }
}
