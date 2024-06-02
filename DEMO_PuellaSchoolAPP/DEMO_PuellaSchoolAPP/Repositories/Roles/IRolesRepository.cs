using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Roles
{
    public interface IRolesRepository
    {
        Task AddAsync(RolModel RolesModel);
        Task DeleteAsync(int id);
        Task EditAsync(RolModel RolesModel);
        Task<IEnumerable<RolModel>> GetAllAsync();
        Task<RolModel?> GetByIdAsync(int id);
    }
}