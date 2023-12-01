using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System.Collections.Generic;
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
        public IEnumerable<ClubService> Get()
        {
            return _dataService.FindAll();
        }
    }
}