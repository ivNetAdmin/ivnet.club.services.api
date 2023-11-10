using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class ConfgController : ApiController
    {
        private readonly IConfigDataService _dataService;

        public ConfgController(ConfigDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("config")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                _dataService.Setup();
                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("config/test")]
        [HttpGet]
        public IHttpActionResult GetTest()
        {
            try
            {
                _dataService.Test();
                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}