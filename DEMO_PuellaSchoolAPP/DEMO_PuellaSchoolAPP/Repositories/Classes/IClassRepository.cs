using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Classes
{
    public interface IClassRepository
    {
        Task AddAsync(ClassModel classs);
        Task DeleteAsync(int id);
        Task EditAsync(ClassModel classs);
        Task<IEnumerable<ClassModel>> GetAllAsync();
        Task<IEnumerable<GradeModel>> GetAllGradesAsync();
        Task<IEnumerable<SectionModel>> GetAllSectionsAsync();
        Task<ClassModel?> GetByIdAsync(int id);
		Task<IEnumerable<ScheduleModel>> GetScheduleByBGSIdAsync(int grd, int sctn);
		Task<IEnumerable<StudentModel>> GetStudentsByClassIdAsync(int classId);
	}
}
