using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;
using MiniExcelLibs;

namespace DEMO_PuellaSchoolAPP.Repositories.Grades
{
    public class GradesRepository : IGradesRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public GradesRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(GradeModel grades)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spGrades_Insert",
                new { grades.GradeName });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spGrades_Delete",
                new { GradeId = id }
                );
        }

        public async Task EditAsync(GradeModel grades)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spGrades_Update",
                grades
                );
        }

        public async Task<IEnumerable<GradeModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<GradeModel, dynamic>(
                "dbo.spGrades_GetAll",
                new { }
                );
        }

        public async Task<GradeModel?> GetByIdAsync(int id)
        {
            var grade = await _dataAccess.GetDataAsync<GradeModel, dynamic>(
                "dbo.spGrades_GetById",
                new { GradeId = id }
                );

            return grade.FirstOrDefault();
        }
    }
}
