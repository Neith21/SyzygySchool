using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Classes
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public SubjectRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(SubjectModel subject)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSubject_Insert",
                new { subject.SubjectName, subject.SubjectInfo, subject.GradeId });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSubject_Delete",
                new { SubjectId = id });
        }

        public async Task EditAsync(SubjectModel subject)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSubject_Update",
                new { subject.SubjectId, subject.SubjectName, subject.SubjectInfo, subject.GradeId });
        }


        public async Task<IEnumerable<SubjectModel>> GetAllAsync()
        {
            var subjects = await _dataAccess.GetDataAsync1<SubjectModel, GradeModel, dynamic>(
                "dbo.spSubjects_GetAll",
                new { },
                (subject, grade) =>
                {
                    subject.Grades = grade;
                    return subject;
                },
                splitOn: "GradeName" // Este debería ser el nombre del campo que divide los resultados
            );
            return subjects;
        }



        public async Task<SubjectModel?> GetByIdAsync(int id)
        {
            var subjects = await _dataAccess.GetDataAsync<SubjectModel, dynamic>(
                "dbo.spSubject_GetById",
                new { SubjectId = id });

            return subjects.FirstOrDefault();
        }
    }
}
