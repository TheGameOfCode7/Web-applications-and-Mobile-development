using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DatabaseLogData : IDatabaseLogData
    {
        private readonly ISqlDataAccess _db;

        public DatabaseLogData(ISqlDataAccess db)
        {
            this._db = db;
        }

        public Task<List<DatabaseLogModel>> GetData()
        {
            string sql = "select * from dbo.DatabaseLog";
            return _db.LoadData<DatabaseLogModel, dynamic>(sql, new { });
        }

        public Task InsertDatabaseLog(DatabaseLogModel dbLogModel)
        {
            string sql = @"insert into dbo.DatabaseLog (DatabaseUser, Event, [Schema], PostTime, Object, TSQL, XmlEvent)
                            values (@DatabaseUser, @Event, @Schema, @PostTime, '', '', '');";
            return _db.SaveData(sql, dbLogModel);
        }

        public Task DeleteDatabaseLog(int logId)
        {
            string sql = @"delete dbo.DatabaseLog WHERE DatabaseLogID=@DatabaseLogID";
            return _db.SaveData(sql, new { DatabaseLogID = logId });
        }

    }
}
