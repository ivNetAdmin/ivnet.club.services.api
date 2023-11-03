using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using System;
using System.Linq;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class MembersController : ApiController
    {
        private readonly MemberDataService _dataService;

        public MembersController(MemberDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("members")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var items = _dataService.FindAll();
            return Ok(items);
        }

        [Route("members/{id}")]
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

        [Route("members/email/{email}/clubcode/{clubcode}")]
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

        [Route("members/username/{userName}")]
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

        [Route("members")]
        [HttpPost]
        public IHttpActionResult Post(Member user)
        {
            _dataService.Add(user);

            return Ok();
        }

        [Route("members/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(string id, Member user)
        {
            var data = _dataService.FindById(id);

            if (user.Password != data.Password)
            {
                data.Password = user.Password;
            }
            else
            {
                data.Fullname = user.Fullname;
                data.Dietary = user.Dietary;
                data.Medical = user.Medical;
                data.Telephone = user.Telephone;
            }

            _dataService.Patch(data);

            return Ok();
        }
    }
}