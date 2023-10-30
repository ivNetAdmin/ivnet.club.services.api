
using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System.Collections.Generic;
using System.Configuration;

namespace ivnet.club.services.api.Services
{
    public class DataService : IDataService
    {
        private string _dbConStr;       

        public DataService()
        {
            var folder = System.AppContext.BaseDirectory;
            _dbConStr = ConfigurationManager.ConnectionStrings["liteDbConStr"].ConnectionString;

            folder = folder.Replace(@"www\", "");
            _dbConStr = _dbConStr.Replace("(folder)", folder);
        }

        public IEnumerable<RinkBooking> FindAll()
        {
            //    var bookings = new List<RinkBooking>
            //    {
            //        new RinkBooking
            //        {
            //           Id = "0d491040-6e82-11ee-9d95-832aabb884ba",
            //            WeekId = 43,
            //            DayId = 1,
            //            TimeId = 1230,
            //            DisplayWeek = "16-22 Oct",
            //            Day = "Mon",
            //            Time = "12:30-14:30",
            //            BookedBy = "bp"
            //        },

            //        new RinkBooking
            //        {
            //            Id = "0d491040-6e82-11ee-9d95-832aabb884bb",
            //            WeekId = 43,
            //            DayId = 1,
            //            TimeId = 1630,
            //            DisplayWeek = "16-22 Oct",
            //            Day = "Mon",
            //            Time = "16:30-18:30",
            //            BookedBy = "bp"
            //        },

            //        new RinkBooking
            //        {
            //            Id = "0d491040-6e82-11ee-9d95-832aabb884bc",
            //            WeekId = 43,
            //            DayId = 2,
            //            TimeId = 1230,
            //            DisplayWeek = "16-22 Oct",
            //            Day = "Tue",
            //            Time = "12:30-14:30",
            //            BookedBy = ""
            //        },

            //        new RinkBooking
            //        {
            //            Id = "0d491040-6e82-11ee-9d95-832aabb884bd",
            //            WeekId = 43,
            //            DayId = 3,
            //            TimeId = 1430,
            //            DisplayWeek = "16-22 Oct",
            //            Day = "Wed",
            //            Time = "14:30-16:30",
            //            BookedBy = "cakes"
            //        }
            //    };

            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<RinkBooking>("rinkBookings").FindAll();
            }
        }
    }
}