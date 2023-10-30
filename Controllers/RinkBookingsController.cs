using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class RinkBookingsController : ApiController
    {
        private readonly DataService _dataService;

        public RinkBookingsController(DataService dataService)
        {
            _dataService = dataService;
        }
        // GET api/RinkBookings
        public IEnumerable<RinkBooking> Get()
        {
            return _dataService.FindAll();
        }
    }
}