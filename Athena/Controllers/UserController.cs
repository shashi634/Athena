using Athena.Models.Dto;
using Athena.Repository;
using Athena.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Athena.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ICustomExceptionValidationService _customExceptionValidationService;
        /// <summary>
        /// User Controller
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        /// <param name="customExceptionValidationService"></param>
        public UserController(IUserService userService, IUserRepository userRepository, ICustomExceptionValidationService customExceptionValidationService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _customExceptionValidationService = customExceptionValidationService;
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
        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="registerUserDto"></param>
        /// <returns></returns>
        [Route("api/User")]
        [HttpPost]
        public async Task<HttpResponseMessage> RegisterUser(RegisterUserDto registerUserDto)
        {
            var data = await _userService.UserRegistartion(registerUserDto);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }
        /// <summary>
        /// Update User Profile
        /// </summary>
        /// <param name="UpdateUserProfile"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("api/User/{userId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateUserProfile(AddUserDto UpdateUserProfile, string userId)
        {
            var data = await _userService.UserProfileUpdate(UpdateUserProfile, userId);
            return Request.CreateResponse(HttpStatusCode.Accepted, data);
        }
        [Route("user/ProfilePic/{userId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> PostUserImage(string userId)
        {
            var data = await _userService.UpdateUserProfilePic(userId);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}
