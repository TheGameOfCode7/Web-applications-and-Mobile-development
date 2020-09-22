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

        public Task<DatabaseLogModel> GetSpecific(int DatabaseLogID)
        {
            string sql = "select * from dbo.DatabaseLog WHERE DatabaseLogID=@DatabaseLogID";
            return _db.LoadSpecific<DatabaseLogModel, dynamic>(sql, new { DatabaseLogID });
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

        public Task SaveData(DatabaseLogModel dbLogModel)
        {
            string sql = @"update dbo.DatabaseLog SET DatabaseUser=@DatabaseUser, Event=@Event, [Schema]=@Schema, PostTime=@PostTime WHERE DatabaseLogID=@DatabaseLogID";
            return _db.SaveData(sql, dbLogModel);
        }

    }
}
