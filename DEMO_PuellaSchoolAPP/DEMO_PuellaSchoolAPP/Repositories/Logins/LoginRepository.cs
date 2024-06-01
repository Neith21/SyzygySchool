using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;
using MiniExcelLibs;

namespace DEMO_PuellaSchoolAPP.Repositories.Logins
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public LoginRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<LoginModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<LoginModel, dynamic>(
                "dbo.spLogin_GetAll",
                new { }
                );
        }

        public async Task<LoginModel?> GetByIdAsync(int id)
        {
            var loginModel = await _dataAccess.GetDataAsync<LoginModel, dynamic>(
                "dbo.spLogin_GetByID",
                new { LoginId = id }
                );

            return loginModel.FirstOrDefault();
        }

        public async Task AddAsync(LoginModel loginModel)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spLogin_Insert",
                new { loginModel.LoginUser, loginModel.LoginPassword, loginModel.TeacherId, loginModel.RoleId });
        }

        public async Task EditAsync(LoginModel loginModel)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spLogin_Update",
                new { loginModel.LoginId, loginModel.LoginUser, loginModel.LoginPassword, loginModel.TeacherId, loginModel.RoleId }
                );
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spLogin_Delete",
                new { loginId = id }
                );
        }
    }
}
