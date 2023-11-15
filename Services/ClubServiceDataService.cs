using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class ClubServiceDataService : IClubServiceDataService
    {
        private string _dbConStr;

        public ClubServiceDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<ClubService> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<ClubService>("ClubServices").FindAll();
            }
        }
    }
}