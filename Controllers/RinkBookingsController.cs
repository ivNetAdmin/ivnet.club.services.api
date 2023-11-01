
using ivnet.club.services.api.Services;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class RinkBookingsController : ApiController
    {
        private readonly RinkBookingDataService _dataService;

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