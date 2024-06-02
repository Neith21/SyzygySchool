﻿using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Classes
{
    public class ClassRepository : IClassRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ClassRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(ClassModel classs)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spClasses_Insert",
                new { classs.ClassInfo, classs.GradeId, classs.SectionId });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spClasses_Delete",
                new { ClassId = id }
                );
        }

        public async Task EditAsync(ClassModel classs)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spClasses_Update",
                new { classs.ClassId, classs.ClassInfo, classs.GradeId, classs.SectionId });
        }

        public async Task<IEnumerable<ClassModel>> GetAllAsync()
        {
            var classes = await _dataAccess.GetData1Async<ClassModel, GradeModel, SectionModel, dynamic>(
                 "dbo.spClasses_GetAll",
                 new { },
                 (classs, grade, section) =>
                 {
                     classs.Grade = grade;
                     classs.Section = section;
                     return classs;
                 },
                 splitOn: "GradeName,SectionName"
             );
            return classes;
        }

		public async Task<IEnumerable<StudentModel>> ClassroomsGetByIdClassAsync()
		{
			return await _dataAccess.GetDataAsync<StudentModel, dynamic>(
				"dbo.spTeachers_GetAll",
				new { }
				);
		}

		public async Task<ClassModel?> GetByIdAsync(int id)
        {
            var classs = await _dataAccess.GetDataAsync<ClassModel, dynamic>(
                "dbo.spClasses_GetById",
                new { ClassId = id }
                );

            return classs.FirstOrDefault();
        }

        public async Task<IEnumerable<GradeModel>> GetAllGradesAsync()
        {
            return await _dataAccess.GetDataAsync<GradeModel, dynamic>(
				"dbo.spGrades_GetAll",
                new { }
                );
        }

        public async Task<IEnumerable<SectionModel>> GetAllSectionsAsync()
        {
            return await _dataAccess.GetDataAsync<SectionModel, dynamic>(
				"dbo.spSections_GetAll",
                new { }
            );
        }
    }
}
