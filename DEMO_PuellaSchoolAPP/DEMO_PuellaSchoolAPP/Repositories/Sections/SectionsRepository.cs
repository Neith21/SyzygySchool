using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;

namespace DEMO_PuellaSchoolAPP.Repositories.Sections
{
    public class SectionsRepository : ISectionsRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public SectionsRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddAsync(SectionModel sections)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSections_Insert",
                new { sections.SectionName, sections.SectionInfo });
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSections_Delete",
                new { SectionId = id }
                );
        }

        public async Task EditAsync(SectionModel sections)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSections_Update",
                sections
                );
        }

        public async Task<IEnumerable<SectionModel>> GetAllAsync()
        {
            return await _dataAccess.GetDataAsync<SectionModel, dynamic>(
                "dbo.spSections_GetAll",
                new { }
                );
        }

        public async Task<SectionModel?> GetByIdAsync(int id)
        {
            var section = await _dataAccess.GetDataAsync<SectionModel, dynamic>(
                "dbo.spSections_GetById",
                new { SectionId = id }
                );

            return section.FirstOrDefault();
        }
    }
}
