using ivnet.club.services.api.Models;
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

                if (fixtures == null || fixtures.Count<Fixture>() == 0)
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

        [Route("fixtures/{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var fixture = _dataService.FindById(id);
                if (fixture != null)
                {
                    return Ok(fixture);
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

        [Route("fixtures/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(string id, Fixture fixture)
        {
            try
            {
                var data = _dataService.FindById(id);

                data.Date = fixture.Date;
                data.Time = fixture.Time;
                data.Opponent = fixture.Opponent;
                data.HomeOrAway = fixture.HomeOrAway;
                data.Kit = fixture.Kit;
                data.Trips = fixture.Trips;

                _dataService.Patch(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}