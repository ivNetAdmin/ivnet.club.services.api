
using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ivnet.club.services.api.Services
{
    public class RinkBookingDataService : IRinkBookingDataService
    {
        private string _dbConStr;
        public RinkBookingDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<RinkBooking> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                //LoadRinkBookings(db);

                return db.GetCollection<RinkBooking>("rinkBookings").FindAll();
            }
        }

        private void LoadRinkBookings(LiteDatabase db)
        {
            var bookings = new List<RinkBooking>
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

            var collection = db.GetCollection<RinkBooking>("rinkBookings");

            foreach(RinkBooking rinkBooking in bookings)
            {
                collection.Insert(rinkBooking);
            }
        }
    }
}