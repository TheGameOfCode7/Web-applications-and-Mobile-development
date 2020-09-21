using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDatabaseLogData
    {
        Task<List<DatabaseLogModel>> GetData();
        Task InsertDatabaseLog(DatabaseLogModel dbLogModel);
        Task DeleteDatabaseLog(int logId);
    }
}