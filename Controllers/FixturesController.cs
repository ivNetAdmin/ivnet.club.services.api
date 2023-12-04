using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System;
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
        public IHttpActionResult Get()
        {
            try
            {
                var fixtures = _dataService.FindAll();

                if (fixtures == null && !fixtures.Any())
                {

                    if (_dataService.BuildAll())
                        fixtures = _dataService.FindAll();
                }

                if (fixtures != null && fixtures.Any())
                {
                    return Ok(fixtures);
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