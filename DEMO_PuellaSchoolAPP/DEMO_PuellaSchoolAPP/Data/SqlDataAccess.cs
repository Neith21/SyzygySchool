using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DEMO_PuellaSchoolAPP.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetDataAsync<T, P>(
            string storedProcedure, P parameters, string connection = "default")
        {
            using IDbConnection dbConnection =
                new SqlConnection(_configuration.GetConnectionString(connection));

            return await dbConnection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> GetDataAsync1<T, U, P>(
   string storedProcedure,
   P parameters,
   Func<T, U, T>? map = null,
   string connection = "default",
   string splitOn = "Id")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connection));

            if (map == null)
            {
                return await dbConnection.QueryAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            else
            {
                return await dbConnection.QueryAsync<T, U, T>(
                    storedProcedure,
                    map,
                    parameters,
                    splitOn: splitOn,
                    commandType: CommandType.StoredProcedure);
            }
        }


        public async Task SaveDataAsync<T>(
            string storedProcedure,
            T parameters,
            string connection = "default")
        {
            using IDbConnection dbConnection =
                new SqlConnection(_configuration.GetConnectionString(connection));

            await dbConnection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> GetData1Async<T, U, V, P>(
        string storedProcedure,
        P parameters,
        Func<T, U, V, T>? map = null,
        string connection = "default",
        string splitOn = "Id")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connection));

            if (map == null)
            {
                return await dbConnection.QueryAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            else
            {
                return await dbConnection.QueryAsync<T, U, V, T>(
                    storedProcedure,
                    map,
                    parameters,
                    splitOn: splitOn,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> GetData2Async<T, U, V, W, P>(
        string storedProcedure,
        P parameters,
        Func<T, U, V, W, T>? map = null,
        string connection = "default",
        string splitOn = "Id")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connection));

            if (map == null)
            {
                return await dbConnection.QueryAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            else
            {
                return await dbConnection.QueryAsync<T, U, V, W, T>(
                    storedProcedure,
                    map,
                    parameters,
                    splitOn: splitOn,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
