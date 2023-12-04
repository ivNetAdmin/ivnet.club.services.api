using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class ClubServiceDataService : IClubServiceDataService
    {
        private readonly ILogDataService _logService;
        private string _dbConStr;

        public ClubServiceDataService(LogDataService logService)
        {
            _logService = logService;
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<ClubService> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<ClubService>("ClubServices").FindAll();
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }
    }
}