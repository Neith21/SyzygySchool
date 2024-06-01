using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Teachers
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>> GetAllAsync();
    }
}