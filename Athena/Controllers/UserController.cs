using Athena.Models.Dto;
using Athena.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Athena.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get User
        /// </summary>
        /// <returns>GetUserDto</returns>
        [Route("api/User")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetUserDetails(string id)
        {
           var data =  await _userService.GetUserByPublicId(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/User")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddUpdateSubject(RegisterUserDto addSubjectDto)
        {
           var data = await _userService.UserRegistartion(addSubjectDto);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
