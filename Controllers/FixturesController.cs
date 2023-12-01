using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class FixturesController : ApiController
    {
        private readonly IFixtureDataService _dataService;

        public FixturesController(FixtureDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("fixtures")]
        [HttpGet]
        public IEnumerable<Fixture> Get()
        {

            var fixtures =  _dataService.FindAll();

            if (fixtures != null && fixtures.Any())
            {
                return fixtures;
            }
            else
            {
                return _dataService.BuildAll();
            }
        }
    }
}