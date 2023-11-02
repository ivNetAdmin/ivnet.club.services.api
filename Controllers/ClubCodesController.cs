using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class ClubCodesController : ApiController
    {
        private readonly ClubCodeDataService _dataService;

        public ClubCodesController(ClubCodeDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<ClubCode> Get()
        {
            return _dataService.FindAll();
        }

        public ClubCode Get(string id)
        {
            return _dataService.FindById(id);
        }

        [Route("clubcodes/code/{code}")]
        public ClubCode GetByCode(string code)
        {
            return _dataService.FindByCode(code);
        }
    }
}