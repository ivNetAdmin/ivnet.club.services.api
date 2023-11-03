using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class ClubCodeDataService : IClubCodeDataService
    {
        private string _dbConStr;
        public ClubCodeDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<ClubCode> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<ClubCode>("ClubCodes").FindAll();
            }
        }

        public ClubCode FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<ClubCode>("ClubCodes").FindById(id);
            }
        }

        public ClubCode FindByCode(string code)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<ClubCode>("ClubCodes").FindOne(Query.EQ("Code", code));
            }
        }
    }
}