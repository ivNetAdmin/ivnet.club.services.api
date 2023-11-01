using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services
{
    public class UserDataService : IUserDataService
    {
        private string _dbConStr;
        public UserDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }
        public IEnumerable<User> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<User>("users").FindAll();
            }
        }

        public User FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<User>("users").FindById(id);
            }
        }
        public User FindByUsername(string username)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<User>("users").FindOne(x => x.Username == username);
            }
        }

        public IEnumerable<User> FindByEmailAndClubCode(string email, string clubcode)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<User>("users").Find(x => x.Email == email && x.ClubCode == clubcode);
            }
        }

        public void Add(User user)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<User>("users");
                collection.Insert(user);
            }
        }

        public void Patch(User user)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<User>("users");
                collection.Update(user);
            }
        }
    }
}