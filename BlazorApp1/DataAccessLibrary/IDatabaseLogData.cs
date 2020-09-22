using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDatabaseLogData
    {
        Task<List<DatabaseLogModel>> GetData();
        Task<DatabaseLogModel> GetSpecific(int DatabaseLogID);
        Task InsertDatabaseLog(DatabaseLogModel dbLogModel);
        Task DeleteDatabaseLog(int logId);
        Task SaveData(DatabaseLogModel dbLogModel);
    }
}