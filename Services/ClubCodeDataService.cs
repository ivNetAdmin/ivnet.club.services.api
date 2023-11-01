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
                //LoadClubCodes(db);
                return db.GetCollection<ClubCode>("clubCodes").FindAll();
            }
        }

        public ClubCode FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<ClubCode>("clubCodes").FindById(id);
            }
        }

        public ClubCode FindByCode(string code)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<ClubCode>("clubCodes").FindOne(Query.EQ("Code", code));
            }
        }

        private void LoadClubCodes(LiteDatabase db)
        {
            var codes = new List<ClubCode>
                {
                    new ClubCode
                    {
                       Id = Guid.NewGuid().ToString(),
                        Code = "TLBC01",
                        Name = "Tring Lawn Bowls Club"
                    },

                    new ClubCode
                    {
                        Id = Guid.NewGuid().ToString(),
                       Code = "FHIBC",
                        Name = "Foxhill Indoor Bowls Club"
                    }
                };

            var collection = db.GetCollection<ClubCode>("clubCodes");

            foreach (ClubCode code in codes)
            {
                collection.Insert(code);
            }
        }
    }
}