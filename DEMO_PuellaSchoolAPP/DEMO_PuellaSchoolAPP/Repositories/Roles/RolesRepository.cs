using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Roles
{
    public class RolesRepository : IRolesRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public RolesRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<RolModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<RolModel, dynamic>(
                "dbo.spRoles_GetAll",
                new { }
                );
        }

        public async Task<RolModel?> GetByIdAsync(int id)
        {
            var RolesModel = await _dataAccess.GetDataAsync<RolModel, dynamic>(
                "dbo.spRoles_GetById",
                new { RoleId = id }
                );

            return RolesModel.FirstOrDefault();
        }

        public async Task AddAsync(RolModel RolesModel)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spRoles_Insert",
                new { RolesModel.RoleName, RolesModel.RoleInfo });
        }

        public async Task EditAsync(RolModel RolesModel)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spRoles_Update",
                new { RolesModel.RoleId, RolesModel.RoleName, RolesModel.RoleInfo }
                );
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spRoles_Delete",
                new { RoleId = id }
                );
        }
    }
}
