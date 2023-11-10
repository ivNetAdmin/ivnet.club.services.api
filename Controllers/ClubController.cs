using ivnet.club.services.api.Helpers;
using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class ClubController : ApiController
    {
        private readonly IClubDataService _dataService;

        public ClubController(ClubDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("clubs")]
        public IEnumerable<Club> Get()
        {
            return _dataService.FindAll();
        }
       
        [Route("clubs/{id}")]
        public Club Get(string id)
        {
            return _dataService.FindById(id);
        }

        [Route("clubs/code/{code}")]
        public Club GetByCode(string code)
        {
            string bearerToken = Request.Headers.Authorization.Parameter;
            var auth = JWTHelper.ValidateCurrentToken(bearerToken);

            return _dataService.FindByCode(code);
        }
    }
}