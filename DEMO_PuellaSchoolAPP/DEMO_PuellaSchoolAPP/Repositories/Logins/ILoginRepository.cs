using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Logins
{
    public interface ILoginRepository
    {
        Task AddAsync(LoginModel loginModel);
        Task DeleteAsync(int id);
        Task EditAsync(LoginModel loginModel);
        Task<IEnumerable<LoginModel>> GetAllAsync();
        Task<LoginModel?> GetByIdAsync(int id);
    }
}