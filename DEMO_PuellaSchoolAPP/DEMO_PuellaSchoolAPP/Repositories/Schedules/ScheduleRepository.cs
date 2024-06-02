using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ScheduleRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(ScheduleModel schedule)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSchedules_Insert",
                new
                {
                    schedule.ScheduleInfo,
                    schedule.ScheduleDay,
                    schedule.ScheduleStart,
                    schedule.ScheduleEnd,
                    schedule.SubjectId,
                    schedule.TeacherId,
                    schedule.ClassId
                });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSchedules_Delete",
                new { IdSchedule = id }
            );
        }

        public async Task EditAsync(ScheduleModel schedule)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSchedules_Update",
                new
                {
                    schedule.IdSchedule,
                    schedule.ScheduleInfo,
                    schedule.ScheduleDay,
                    schedule.ScheduleStart,
                    schedule.ScheduleEnd,
                    schedule.SubjectId,
                    schedule.TeacherId,
                    schedule.ClassId
                });
        }

        public async Task<IEnumerable<ScheduleModel>> GetAllAsync()
        {
            var schedules = await _dataAccess.GetData2Async<ScheduleModel, SubjectModel, TeacherModel, ClassModel, dynamic>(
                "dbo.spSchedules_GetAll",
                new { },
                (schedule, subject, teacher, classs) =>
                {
                    schedule.Subject = subject;
                    schedule.Teacher = teacher;
                    schedule.Class = classs;
                    return schedule;
                },
                splitOn: "SubjectName,TeacherName,ClassInfo"
            );

            return schedules;
        }

        public async Task<ScheduleModel?> GetByIdAsync(int id)
        {
            var schedule = await _dataAccess.GetDataAsync<ScheduleModel, dynamic>(
                "dbo.spSchedules_GetById",
                new { IdSchedule = id }
            );

            return schedule.FirstOrDefault();
        }

        public async Task<IEnumerable<SubjectModel>> GetAllSubjectAsync()
        {
            return await _dataAccess.GetDataAsync<SubjectModel, dynamic>(
                "dbo.spSubjects_GetAll",
                new { }
            );
        }

        public async Task<IEnumerable<TeacherModel>> GetAllTeacherAsync()
        {
            return await _dataAccess.GetDataAsync<TeacherModel, dynamic>(
				"dbo.spTeachers_GetAll",
                new { }
            );
        }

        public async Task<IEnumerable<ClassModel>> GetAllClassAsync()
        {
            return await _dataAccess.GetDataAsync<ClassModel, dynamic>(
                "dbo.spClasses_GetAll",
                new { }
            );
        }
    }
}
