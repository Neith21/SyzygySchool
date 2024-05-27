using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.RStudents
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public StudentsRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(StudentsModel students)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spStudents_Insert",
                new { students.StudentName, students.StudentLastName, students.StudentAge, students.StudentGender, students.StudentParentName });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spStudents_Delete",
                new { StudentId = id }
                );
        }

        public async Task EditAsync(StudentsModel students)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spStudents_Update",
                students
                );
        }

        public async Task<IEnumerable<StudentsModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<StudentsModel, dynamic>(
                "dbo.spStudents_GetAll",
                new { }
                );
        }

        public async Task<StudentsModel?> GetByIdAsync(int id)
        {
            var student = await _dataAccess.GetDataAsync<StudentsModel, dynamic>(
                "dbo.spStudents_GetById",
                new { StudentId = id }
                );

            return student.FirstOrDefault();
        }
    }
}
