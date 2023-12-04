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
    public class MembersController : ApiController
    {
        private readonly IMemberDataService _dataService;

        public MembersController(MemberDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("members")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var members = _dataService.FindAll();

                if (members != null && members.Any())
                {
                    var memberList = new List<Member>();
                    foreach (Member member in members)
                    {
                        member.Password = string.Empty;
                        member.Email = string.Empty;
                        memberList.Add(member);
                    }

                    return Ok(memberList);
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            
        }

        [Route("members/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var member = _dataService.FindById(id);

                if (member != null)
                {
                    member.Password = string.Empty;
                    member.Email = string.Empty;
                    return Ok(member);
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
                var members = _dataService.FindByEmailAndClubCode(email, clubcode);

                if (members != null && members.Any())
                {
                    var memberList = new List<Member>();
                    foreach (Member member in members)
                    {
                        member.Password = string.Empty;
                        memberList.Add(member);
                    }

                    return Ok(memberList);
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

        [Route("members/authenticate/{username}/{password}")]
        [HttpGet]
        public IHttpActionResult GetByUsernameAndPassword(string username, string password)
        {
            try
            {
                var member = _dataService.FindByUsernameAndPassword(username, password);

                if (member != null)
                {
                    member.Auth = JWTHelper.GenerateToken(member.Id);
                    member.Password = string.Empty;
                    member.Email = string.Empty;
                    return Ok(member);
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

        [Route("members/clubcode/{clubcode}")]
        [HttpGet]
        public IHttpActionResult GetByClubCode(string clubcode)
        {
            try
            {
                var members = _dataService.FindByClubCode(clubcode);
                if (members != null && members.Any())
                {
                    return Ok(members);
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
                var member = _dataService.FindByUsername(userName);

                if (member != null)
                {
                    member.Password = string.Empty;
                    member.Email = string.Empty;
                    return Ok(member);
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
        public IHttpActionResult Post(Member member)
        {
            try
            {
                _dataService.Add(member);

                member.Auth = JWTHelper.GenerateToken(member.Id);
                member.Password = string.Empty;
                member.Email = string.Empty;
                return Ok(member);
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("members/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(string id, Member user)
        {
            try { 
            var data = _dataService.FindById(id);

            if (user.Password != null)
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

            data.Password = string.Empty;
            data.Email = string.Empty;

            return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}