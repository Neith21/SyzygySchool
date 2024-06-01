using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Roles
{
    public interface IRolesRepository
    {
        Task AddAsync(RolesModel RolesModel);
        Task DeleteAsync(int id);
        Task EditAsync(RolesModel RolesModel);
        Task<IEnumerable<RolesModel>> GetAllAsync();
        Task<RolesModel?> GetByIdAsync(int id);
    }
}