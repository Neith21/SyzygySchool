using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public TeacherRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<TeacherModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<TeacherModel, dynamic>(
                "dbo.spTeachers_GetAll",
                new { }
                );
        }
    }
}
