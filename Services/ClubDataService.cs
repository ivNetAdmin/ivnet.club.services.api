using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class ClubDataService : IClubDataService
    {
        private readonly ILogDataService _logService;
        private string _dbConStr;
        public ClubDataService(LogDataService logService)
        {
            _logService = logService;
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<Club> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Club>("Clubs").FindAll();
                }catch(Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }

        public Club FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Club>("Clubs").FindById(id);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }

        public Club FindByCode(string code)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Club>("Clubs").FindOne(Query.EQ("Code", code));
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