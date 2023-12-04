using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class MemberDataService : IMemberDataService
    {
        private readonly ILogDataService _logService;
        private string _dbConStr;
        public MemberDataService(LogDataService logService)
        {
            _logService = logService;
            _dbConStr = DatabaseConnection.Location;
        }
        public IEnumerable<Member> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Member>("Members").FindAll();
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }

        public Member FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Member>("Members").FindById(id);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }
        public Member FindByUsername(string username)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Member>("Members").FindOne(x => x.Username == username);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }                
            }
        }

        public IEnumerable<Member> FindByEmailAndClubCode(string email, string clubcode)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Member>("Members").Find(x => x.Email == email && x.ClubCode == clubcode);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }   
            }
        }

        public IEnumerable<Member> FindByClubCode(string clubcode)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Member>("Members").Find(x => x.ClubCode == clubcode);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                } 
            }
        }

        public Member FindByUsernameAndPassword(string username, string password)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Member>("Members").FindOne(x => x.Username == username && x.Password == password);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }

        public void Add(Member member)
        {
            try
            {
                member.Id = Guid.NewGuid().ToString();
                using (var db = new LiteDatabase(_dbConStr))
                {
                    var collection = db.GetCollection<Member>("Members");
                    collection.Insert(member);
                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                throw ex;
            }
        }

        public void Patch(Member member)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    var collection = db.GetCollection<Member>("Members");
                    collection.Update(member);
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