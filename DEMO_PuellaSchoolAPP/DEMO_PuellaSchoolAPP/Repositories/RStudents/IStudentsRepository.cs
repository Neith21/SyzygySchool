using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.RStudents
{
    public interface IStudentsRepository
    {
        Task AddAsync(StudentModel students);
        Task DeleteAsync(int id);
        Task EditAsync(StudentModel students);
        Task<IEnumerable<StudentModel>> GetAllAsync();
        Task<StudentModel?> GetByIdAsync(int id);
    }
}
