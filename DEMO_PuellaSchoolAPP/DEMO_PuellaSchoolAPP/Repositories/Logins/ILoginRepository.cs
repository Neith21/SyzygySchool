using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Logins
{
    public interface ILoginRepository
    {
        Task AddAsync(LoginModel loginModel);
        Task DeleteAsync(int id);
        Task EditAsync(LoginModel loginModel);
        Task<IEnumerable<LoginModel>> GetAllAsync();
        Task<IEnumerable<LoginModel>> GetAllAsyncLogin();
        Task<IEnumerable<RolModel>> GetAllRolesAsync();
        Task<IEnumerable<TeacherModel>> GetAllTeachersAsync();
        Task<LoginModel?> GetByIdAsync(int id);
    }
}