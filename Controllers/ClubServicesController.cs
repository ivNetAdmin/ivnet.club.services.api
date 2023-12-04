using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace ivnet.club.services.api.Controllers
{
    public class ClubServicesController : ApiController
    {
        private readonly IClubServiceDataService _dataService;

        public ClubServicesController(ClubServiceDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("clubservices")]
        public IHttpActionResult Get()
        {
            try
            {
                var clubservices = _dataService.FindAll();
                if (clubservices != null && clubservices.Any())
                {
                    return Ok(clubservices);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}