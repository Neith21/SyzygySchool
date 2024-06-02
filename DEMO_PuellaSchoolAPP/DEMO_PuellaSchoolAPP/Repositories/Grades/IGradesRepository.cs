using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Grades
{
    public interface IGradesRepository
    {
        Task AddAsync(GradeModel grades);
        Task DeleteAsync(int id);
        Task EditAsync(GradeModel grades);
        Task<IEnumerable<GradeModel>> GetAllAsync();
        Task<GradeModel?> GetByIdAsync(int id);
    }
}