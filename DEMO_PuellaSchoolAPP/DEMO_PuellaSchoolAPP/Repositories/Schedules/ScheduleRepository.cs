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
                "dbo.spSchedule_Insert",
                new
                {
                    schedule.ScheduleInfo,
                    schedule.ScheduleCreation,
                    schedule.ScheduleStart,
                    schedule.ScheduleEnd,
                    schedule.ScheduleExpiration,
                    schedule.SubjectId,
                    schedule.TeacherId,
                    schedule.ClassId
                });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSchedules_Delete",
                new { ScheduleId = id }
            );
        }

        public async Task EditAsync(ScheduleModel schedule)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSchedules_Update",
                schedule
            );
        }

        public async Task<IEnumerable<ScheduleModel>> GetAllAsync()
        {
            var schedules = await _dataAccess.GetDataForeignAsync<ScheduleModel, SubjectModel, TeacherModel, dynamic>(
                "dbo.spSchedules_GetAll",
                new { },
                (schedule, subject, teacher) =>
                {
                    schedule.Subject = subject;
                    schedule.Teacher = teacher;
                    return schedule;
                },
                splitOn: "SubjectName,TeacherName"
            );

            return schedules;
        }

        public async Task<ScheduleModel?> GetByIdAsync(int id)
        {
            var schedule = await _dataAccess.GetDataAsync<ScheduleModel, dynamic>(
                "dbo.spSchedules_GetById",
                new { ScheduleId = id }
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
    }
}
