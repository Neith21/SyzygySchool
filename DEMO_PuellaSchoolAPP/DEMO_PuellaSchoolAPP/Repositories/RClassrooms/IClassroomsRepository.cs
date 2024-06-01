using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.RClassrooms
{
    public interface IClassroomsRepository
    {
        Task AddAsync(ClassroomModel classrooms);
        Task DeleteAsync(int id);
        Task EditAsync(ClassroomModel classrooms);
        Task<IEnumerable<ClassroomModel>> GetAllAsync();
        Task<IEnumerable<StudentModel>> GetAllStudents();
        Task<ClassroomModel?> GetByIdAsync(int id);
    }
}
