using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using System;
using System.Linq;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UserDataService _dataService;

        public UsersController(UserDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("users")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var items = _dataService.FindAll();
            return Ok(items);
        }

        [Route("users/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var data = _dataService.FindById(id);

                if (data != null)
                {
                    return Ok(data);
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

        [Route("users/email/{email}/clubcode/{clubcode}")]
        [HttpGet]
        public IHttpActionResult GetByEmailAndClubCode(string email, string clubcode)
        {
            try
            {
                var data = _dataService.FindByEmailAndClubCode(email, clubcode);

                if (data != null && data.Any())
                {
                    return Ok(data);
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

        [Route("users/username/{userName}")]
        [HttpGet]
        public IHttpActionResult GetByUserName(string userName)
        {
            try
            {
                var data = _dataService.FindByUsername(userName);

                if (data != null)
                {
                    return Ok(data);
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

        [Route("users")]
        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            _dataService.Add(user);

            return Ok();
        }

        [Route("users/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(string id, User user)
        {
            var data = _dataService.FindById(id);
            data.Fullname = user.Fullname;
            data.Dietary = user.Dietary;
            data.Medical = user.Medical;
            data.Telephone = user.Telephone;

            _dataService.Patch(data);

            return Ok();
        }
    }
}