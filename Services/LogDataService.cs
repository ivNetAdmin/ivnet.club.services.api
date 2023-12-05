using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;

namespace ivnet.club.services.api.Services
{
    public class LogDataService : ILogDataService
    {
        private string _dbConStr;
        public LogDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }

        public void LogError(Exception ex)
        {
            var logError = new ErrorLog
            {
                Id = Guid.NewGuid().ToString(),
                Message = ex.Message,
                InnerMessage = ex.InnerException == null ? string.Empty : ex.InnerException.Message,
                Service = ex.TargetSite.DeclaringType.Name,
                Method = ex.TargetSite.Name
            };

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<ErrorLog>("ErrorLogs");
                collection.Insert(logError);
            }
        }
    }
}