using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Sections
{
    public interface ISectionsRepository
    {
        Task AddAsync(SectionModel sections);
        Task DeleteAsync(int id);
        Task EditAsync(SectionModel sections);
        Task<IEnumerable<SectionModel>> GetAllAsync();
        Task<SectionModel?> GetByIdAsync(int id);
    }
}