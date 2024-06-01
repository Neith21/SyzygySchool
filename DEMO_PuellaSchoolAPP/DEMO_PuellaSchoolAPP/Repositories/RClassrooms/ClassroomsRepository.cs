using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.RClassrooms
{
    public class ClassroomsRepository : IClassroomsRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ClassroomsRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(ClassroomModel classrooms)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spClassrooms_Insert",
                new { classrooms.ClassId, classrooms.StudentId });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spClassrooms_Delete",
                new { ClassroomId = id }
                );
        }

        public async Task EditAsync(ClassroomModel classrooms)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spClasrooms_Update",
                classrooms
                );
        }

        public async Task<IEnumerable<ClassroomModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<ClassroomModel, dynamic>(
                "dbo.spClassrooms_GetAll",
                new { }
                );
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            return await _dataAccess.GetDataAsync<StudentModel, dynamic>(
                "dbo.spStudents_GetAll",
                new { }
                );
        }

        public async Task<ClassroomModel?> GetByIdAsync(int id)
        {
            var classroom = await _dataAccess.GetDataAsync<ClassroomModel, dynamic>(
                "dbo.spClassrooms_GetById",
                new { ClassroomId = id }
                );

            return classroom.FirstOrDefault();
        }
    }
}
