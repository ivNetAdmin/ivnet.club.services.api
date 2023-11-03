using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ivnet.club.services.api.Services
{
    public class ConfigDataService : IConfigDataService
    {
        private string _dbConStr;
        private readonly string _saEmail = "clubservices@ivnet.co.uk";
        private readonly string _saRole = "SA";
    
        public ConfigDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }

        public void Prod()
        {
            throw new System.NotImplementedException();
        }

        public void Setup()
        {
            LoadClubCodes();
            LoadSA();
            LoadMemberRoles();
            SetMemberRoles();
        }

        public void Test()
        {
            LoadRinkBookings();
        }

        private void LoadSA()
        {
            var clubCodes = GetClubCodes();

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<Member>("Members");
                collection.DeleteAll();

                foreach (ClubCode clubCode in clubCodes)
                {
                    var user = new Member
                    {
                        Id = Guid.NewGuid().ToString(),
                        Username = $"SA{clubCode.Code}",
                        Password = "'nDTa6VN5W/sSl0TIoQrJgg=='",
                        ClubCode = clubCode.Code,
                        ClubName = clubCode.Name,
                        Fullname = $"SA{clubCode.Code}",
                        Email = _saEmail
                    };

                    collection.Insert(user);
                }
            }
        }

        private void LoadClubCodes()
        {
            var clubCodes = GetClubCodes();

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<ClubCode>("ClubCodes");
                collection.DeleteAll();

                foreach (ClubCode clubCode in clubCodes)
                {
                    collection.Insert(clubCode);
                }
            }
        }

        private void LoadMemberRoles()
        {
            var clubRoles = GetClubRoles();

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<ClubRole>("ClubRoles");
                collection.DeleteAll();

                foreach (ClubRole clubRole in clubRoles)
                {
                    collection.Insert(clubRole);
                }
            }
        }

        public void LoadRinkBookings()
        {
            var bookings = GetRinkBookings();

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<RinkBooking>("RinkBookings");
                collection.DeleteAll();

                foreach (RinkBooking rinkBooking in bookings)
                {
                    collection.Insert(rinkBooking);
                }
            }
        }

        private void SetMemberRoles()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<MemberClubRole>("MemberClubRoles");
                collection.DeleteAll();

                var memberCollection = db.GetCollection<Member>("Members").Find(x => x.Email == _saEmail).ToList();
                var saRole = db.GetCollection<ClubRole>("ClubRoles").Find(x => x.Role == _saRole).ToList();

                foreach (Member member in memberCollection)
                {
                    var memberClubRole = new MemberClubRole
                    {
                        MemberId = member.Id,
                        RoleId = saRole.First().Id
                    };

                    collection.Insert(memberClubRole);
                }
            }
        }

        private List<ClubCode> GetClubCodes()
        {
            return new List<ClubCode>
                {
                    new ClubCode
                    {
                       Id = Guid.NewGuid().ToString(),
                        Code="TLBC01",
                        Name="Tring Lawn Bowls Club"
                    },
                    new ClubCode
                    {
                       Id = Guid.NewGuid().ToString(),
                        Code="FHIBC",
                        Name="Foxhill Indoor Bowls Club"
                    }
            };
        }

        private List<ClubRole> GetClubRoles()
        {
            return new List<ClubRole>
                {
                new ClubRole
                    {
                       Id = Guid.NewGuid().ToString(),
                        Role=_saRole,
                        Name="Super Administrator"
                    },
                    new ClubRole
                    {
                       Id = Guid.NewGuid().ToString(),
                        Role="Admin",
                        Name="Club Administrator"
                    },
                    new ClubRole
                    {
                       Id = Guid.NewGuid().ToString(),
                        Role="Fixture",
                        Name="Fixture Secretary"
                    },
                     new ClubRole
                    {
                       Id = Guid.NewGuid().ToString(),
                        Role="Booking",
                        Name="Booking Secretary"
                    },
                    new ClubRole
                    {
                       Id = Guid.NewGuid().ToString(),
                        Role="Committee",
                        Name="Committee Member"
                    }
            };
        }

        private List<RinkBooking> GetRinkBookings()
        {
            return new List<RinkBooking>
                {
                    new RinkBooking
                    {
                       Id = Guid.NewGuid().ToString(),
                        WeekId = 43,
                        DayId = 1,
                        TimeId = 1230,
                        DisplayWeek = "16-22 Oct",
                        Day = "Mon",
                        Time = "12:30-14:30",
                        BookedBy = "bp"
                    },

                    new RinkBooking
                    {
                        Id = Guid.NewGuid().ToString(),
                        WeekId = 43,
                        DayId = 1,
                        TimeId = 1630,
                        DisplayWeek = "16-22 Oct",
                        Day = "Mon",
                        Time = "16:30-18:30",
                        BookedBy = "bp"
                    },

                    new RinkBooking
                    {
                        Id = Guid.NewGuid().ToString(),
                        WeekId = 43,
                        DayId = 2,
                        TimeId = 1230,
                        DisplayWeek = "16-22 Oct",
                        Day = "Tue",
                        Time = "12:30-14:30",
                        BookedBy = ""
                    },

                    new RinkBooking
                    {
                        Id = Guid.NewGuid().ToString(),
                        WeekId = 43,
                        DayId = 3,
                        TimeId = 1430,
                        DisplayWeek = "16-22 Oct",
                        Day = "Wed",
                        Time = "14:30-16:30",
                        BookedBy = "cakes"
                    }
                };
        }
    }
}