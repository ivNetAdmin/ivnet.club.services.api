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
            LoadClubs();
            LoadClubServices();
           // LoadSA();
           // LoadMemberRoles();
           // SetMemberRoles();
        }

        public void Test()
        {
            LoadRinkBookings();
        }

        private void LoadSA()
        {
            var clubs = GetClubs();

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<Member>("Members");
                collection.DeleteAll();

                foreach (Club club in clubs)
                {
                    var user = new Member
                    {
                        Id = Guid.NewGuid().ToString(),
                        Username = $"SA{club.Code}",
                        Password = "'nDTa6VN5W/sSl0TIoQrJgg=='",
                        ClubCode = club.Code,
                        ClubName = club.Name,
                        Fullname = $"SA{club.Code}",
                        Email = _saEmail
                    };

                    collection.Insert(user);
                }
            }
        }

        private void LoadClubs()
        {
            var clubs = GetClubs();

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<Club>("Clubs");
                collection.DeleteAll();

                foreach (Club club in clubs)
                {
                    collection.Insert(club);
                }
            }
        }

        private void LoadClubServices()
        {
            var services = GetServices();

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<ClubService>("ClubServices");
                collection.DeleteAll();

                foreach (ClubService service in services)
                {
                    collection.Insert(service);
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

        private List<Club> GetClubs()
        {
            return new List<Club>
                {
                    new Club
                    {
                       Id = Guid.NewGuid().ToString(),
                        Code="TLBC01",
                        Name="Tring Lawn Bowls Club"
                    },
                    new Club
                    {
                       Id = Guid.NewGuid().ToString(),
                        Code="FHIBC",
                        Name="Foxhill Indoor Bowls Club"
                    }
            };
        }

        private List<ClubService> GetServices()
        {
            return new List<ClubService>
                {
                    new ClubService
                    {
                       Id = Guid.NewGuid().ToString(),
                        Name="Rink Booking",
                        Description="Book rinks and check schedule and availability",
                        SVG="rinkBooking",
                        Route="rink-booking"
                    },
                    new ClubService
                    {
                       Id = Guid.NewGuid().ToString(),
                        Name="Fixtures",
                        Description="Check schedule and update your availability to play",
                        SVG="fixtures",
                        Route="fixtures"
                    },
                     new ClubService
                    {
                       Id = Guid.NewGuid().ToString(),
                        Name="My Information",
                        Description="Update your dietary, medical and contact information. This information will only be used by match captains and catering teams",
                        SVG="myInformation",
                        Route="my-information"
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