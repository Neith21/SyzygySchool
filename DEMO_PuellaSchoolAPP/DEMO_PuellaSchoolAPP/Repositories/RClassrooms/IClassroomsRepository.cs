using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.RClassrooms
{
    public interface IClassroomsRepository
    {
        Task AddAsync(ClassroomsModel classrooms);
        Task DeleteAsync(int id);
        Task EditAsync(ClassroomsModel classrooms);
        Task<IEnumerable<ClassroomsModel>> GetAllAsync();
        Task<IEnumerable<StudentsModel>> GetAllStudents();
        Task<ClassroomsModel?> GetByIdAsync(int id);
    }
}
