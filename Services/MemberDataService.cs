using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class MemberDataService : IMemberDataService
    {
        private string _dbConStr;
        public MemberDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }
        public IEnumerable<Member> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<Member>("Members").FindAll();
            }
        }

        public Member FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<Member>("Members").FindById(id);
            }
        }
        public Member FindByUsername(string username)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<Member>("Members").FindOne(x => x.Username == username);
            }
        }

        public IEnumerable<Member> FindByEmailAndClubCode(string email, string clubcode)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<Member>("Members").Find(x => x.Email == email && x.ClubCode == clubcode);
            }
        }

        public void Add(Member member)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<Member>("Members");
                collection.Insert(member);
            }
        }

        public void Patch(Member member)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<Member>("Members");
                collection.Update(member);
            }
        }
    }
}