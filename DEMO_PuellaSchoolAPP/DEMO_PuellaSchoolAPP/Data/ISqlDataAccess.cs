using System.Data;

namespace DEMO_PuellaSchoolAPP.Data
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetDataAsync<T, P>(string storedProcedure, P parameters, string connection = "default");
		Task<IEnumerable<T>> GetDataForeignAsync<T, U, V, P>(string storedProcedure, P parameters, Func<T, U, V, T>? map = null, string connection = "default", string splitOn = "Id");
        Task<IEnumerable<T>> GetDataClassroomsForeignAsync<T, U, P>(string storedProcedure, P parameters, Func<T, U, T>? map = null, string connection = "default", string splitOn = "Id");
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connection = "default");
    }
}
