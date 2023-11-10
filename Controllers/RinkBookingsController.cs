
using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class RinkBookingsController : ApiController
    {
        private readonly IRinkBookingDataService _dataService;

        public RinkBookingsController(RinkBookingDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("rinkbookings")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = _dataService.FindAll();

            try
            {
                if (data != null && data.Any())
                {
                    return Ok(data);
                }
                else
                {
                    return Ok(HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                return Ok(HttpStatusCode.InternalServerError);
            }
        }
    }
}