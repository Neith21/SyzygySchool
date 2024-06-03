using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Classes
{
    public interface ISubjectRepository
    {
        Task AddAsync(SubjectModel subject);
        Task DeleteAsync(int id);
        Task EditAsync(SubjectModel subject);
        Task<IEnumerable<SubjectModel>> GetAllAsync();
        Task<SubjectModel?> GetByIdAsync(int id);
    }
}