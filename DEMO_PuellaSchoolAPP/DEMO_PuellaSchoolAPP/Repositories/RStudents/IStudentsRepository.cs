using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.RStudents
{
    public interface IStudentsRepository
    {
        Task AddAsync(StudentsModel students);
        Task DeleteAsync(int id);
        Task EditAsync(StudentsModel students);
        Task<IEnumerable<StudentsModel>> GetAllAsync();
        Task<StudentsModel?> GetByIdAsync(int id);
    }
}
