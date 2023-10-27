using ivnet.club.services.api.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class RinkBookingsController : ApiController
    {
        // GET api/RinkBookings
        public IHttpActionResult Get()
        {
            var bookings = new List<RinkBooking>
            {
                new RinkBooking
                {
                    Id = "0d491040-6e82-11ee-9d95-832aabb884ba",
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
                    Id = "0d491040-6e82-11ee-9d95-832aabb884bb",
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
                    Id = "0d491040-6e82-11ee-9d95-832aabb884bc",
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
                    Id = "0d491040-6e82-11ee-9d95-832aabb884bd",
                    WeekId = 43,
                    DayId = 3,
                    TimeId = 1430,
                    DisplayWeek = "16-22 Oct",
                    Day = "Wed",
                    Time = "14:30-16:30",
                    BookedBy = "cakes"
                }
            };

            return Ok(bookings);

        }
    }
}