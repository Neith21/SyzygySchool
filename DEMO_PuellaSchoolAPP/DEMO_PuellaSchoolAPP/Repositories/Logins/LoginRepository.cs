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

        public async Task<IEnumerable<TeacherModel>> GetAllTeachersAsync()
        {
            return await _dataAccess.GetDataAsync<TeacherModel, dynamic>(
                "dbo.spTeachers_GetAll",
                new { }
                );
        }

        public async Task<IEnumerable<RolModel>> GetAllRolesAsync()
        {
            return await _dataAccess.GetDataAsync<RolModel, dynamic>(
                "dbo.spRoles_GetAll",
                new { }
                );
        }

        public async Task<IEnumerable<LoginModel>> GetAllAsyncLogin()
        {
            return await _dataAccess.GetDataAsync<LoginModel, dynamic>(
                "dbo.spLogin_Login",
                new { }
                );
        }

        public async Task<IEnumerable<LoginModel>> GetAllAsync()
        {
            var logins = await _dataAccess.GetData1Async<LoginModel, TeacherModel, RolModel, dynamic>(
                "dbo.spLogin_GetAll",
                new { },
                (login, teacher, rol) =>
                 {
                     login.Teacher = teacher;
                     login.Roles = rol;
                     return login;
                 },
                 splitOn: "TeacherName, RoleName"
             );
            return logins;
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
