using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.RTeachers
{
    public interface ITeacherRepository
    {
        Task AddAsync(TeacherModel teacher);
        Task DeleteAsync(int id);
        Task EditAsync(TeacherModel teacher);
        Task<IEnumerable<TeacherModel>> GetAllAsync();
        Task<TeacherModel?> GetByIdAsync(int id);
        Task ImportDataAsync(string filePath);
    }
}