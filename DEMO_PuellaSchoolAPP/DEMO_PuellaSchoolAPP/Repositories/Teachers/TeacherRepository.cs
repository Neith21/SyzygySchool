using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;
using MiniExcelLibs;

namespace DEMO_PuellaSchoolAPP.Repositories.RTeachers
{
    public class TeachersRepository : ITeacherRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public TeachersRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(TeacherModel teacher)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spTeachers_Insert",
                new { teacher.TeacherName, teacher.TeacherLastName, teacher.TeacherAge, teacher.TeacherGender, teacher.TeacherPhone, teacher.TeacherEmail });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spTeachers_Delete",
                new { TeacherId = id }
                );
        }

        public async Task EditAsync(TeacherModel teacher)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spTeachers_Update",
                teacher
                );
        }

        public async Task<IEnumerable<TeacherModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<TeacherModel, dynamic>(
                "dbo.spTeachers_GetAll",
                new { }
                );
        }

        public async Task<TeacherModel?> GetByIdAsync(int id)
        {
            var teacher = await _dataAccess.GetDataAsync<TeacherModel, dynamic>(
                "dbo.spTeachers_GetById",
                new { TeacherId = id }
                );

            return teacher.FirstOrDefault();
        }

        public async Task ImportDataAsync(string filePath)
        {
            var rows = MiniExcel.Query<TeacherModel>(filePath).ToList();

            foreach (var row in rows)
            {
                var parameters = new
                {
                    row.TeacherName,
                    row.TeacherLastName,
                    row.TeacherAge,
                    row.TeacherGender,
                    row.TeacherPhone,
                    row.TeacherEmail
                  
                };

                await _dataAccess.SaveDataAsync("dbo.spTeachers_Insert", parameters);
            }
        }
    }
}
