using ivnet.club.services.api.Helpers;
using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class ClubsController : ApiController
    {
        private readonly IClubDataService _dataService;

        public ClubsController(ClubDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("clubs")]
        public IHttpActionResult Get()
        {
            try
            {
                var clubs = _dataService.FindAll();
                if (clubs != null && clubs.Any())
                {
                    return Ok(clubs);
                }
                else {
                    return NotFound();
                }   
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
       
        [Route("clubs/{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var club = _dataService.FindById(id);
                if (club != null)
                {
                    return Ok(club);
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

        [Route("clubs/code/{code}")]
        public IHttpActionResult GetByCode(string code)
        {
            try
            {
                if (Request.Headers.Authorization == null) return Unauthorized();

                string bearerToken = Request.Headers.Authorization.Parameter;
                if(JWTHelper.ValidateCurrentToken(bearerToken))
                {
                    var club = _dataService.FindByCode(code);
                    if (club != null)
                    {
                        return Ok(club);
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}