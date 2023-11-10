using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class ClubDataService : IClubDataService
    {
        private string _dbConStr;
        public ClubDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<Club> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                
                return db.GetCollection<Club>("Clubs").FindAll();
            }
        }

        public Club FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<Club>("Clubs").FindById(id);
            }
        }

        public Club FindByCode(string code)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<Club>("Clubs").FindOne(Query.EQ("Code", code));
            }
        }
    }
}