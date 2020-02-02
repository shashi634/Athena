using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Athena.Models;
using Athena.Models.Dto;
using Athena.Repository;

namespace Athena.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICustomExceptionValidationService _customExceptionValidationService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="customExceptionValidationService"></param>
        /// <param name="organizationRepository"></param>
        public UserService(IUserRepository userRepository, 
            ICustomExceptionValidationService customExceptionValidationService,
            IOrganizationRepository organizationRepository) {
            _userRepository = userRepository;
            _customExceptionValidationService = customExceptionValidationService;
            _organizationRepository = organizationRepository;
        }
        /// <summary>
        /// Get User By PublicId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetUserDto> GetUserByPublicId(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid userPublicId);
            if (!isValid)
            {
                _customExceptionValidationService.CustomValidation("Invalid user Id", HttpStatusCode.BadRequest);
            }
            var userDetails = _userRepository.GetUserByGuid(userPublicId);
            if (userDetails == null)
            {
                _customExceptionValidationService.CustomValidation("User doesn't exists!", HttpStatusCode.NotFound);
            }
            var userDto = new GetUserDto { 
                Name = userDetails.Name,
                EmailId = userDetails.EmailId,
                MobileNo = userDetails.MobileNo,
                Address = userDetails.Address,
                ProfilePic = userDetails.ProfilePic,
                ActivationDate = userDetails.ActivationDate,
                City = userDetails.City,
                PinCode = userDetails.PinCode,
                AssociatedOrganization = new OrganizationDto { 
                    Name = userDetails.Organization.Name, 
                    PublicId = Convert.ToString(userDetails.Organization.PublicId),
                    Address = userDetails.Organization.Address,
                    PinCode = userDetails.Organization.PinCode,
                    ActivationDate = userDetails.Organization.ActivationDate,
                    City = userDetails.Organization.City,
                    Description = userDetails.Organization.Description,
                    IsActive = userDetails.Organization.IsActive
                },

            };
            return await Task.FromResult(userDto);
        }

        public async Task<ReturnUserProfilePic> UpdateUserProfilePic(string userId)
        {
            try
            {
                string userProfilePicUrl = string.Empty;
                var httpRequest = HttpContext.Current.Request;
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB
                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", "jpeg" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            _customExceptionValidationService.CustomValidation("Please Upload image of type .jpg,.jprg,.gif,.png.", HttpStatusCode.BadRequest);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            _customExceptionValidationService.CustomValidation("Please Upload a file upto 1 mb.", HttpStatusCode.BadRequest);
                        }
                        else
                        {
                            bool isValid = Guid.TryParse(userId, out Guid userPublicId);
                            if (!isValid)
                            {
                                _customExceptionValidationService.CustomValidation("Invalid user Id", HttpStatusCode.BadRequest);
                            }
                            var userInfo = _userRepository.GetUserByGuid(userPublicId);
                            if (userInfo == null) {
                                _customExceptionValidationService.CustomValidation("User not registered", HttpStatusCode.NotFound);
                            }
                            userInfo.ProfilePic = userInfo.Name+"-"+Convert.ToString(Guid.NewGuid()) + extension;
                            userProfilePicUrl = userInfo.ProfilePic;
                            var filePath = HttpContext.Current.Server.MapPath("~/Userimage/" + userInfo.ProfilePic);
                            postedFile.SaveAs(filePath);
                            await _userRepository.UpdateUser(userInfo);
                        }
                    }
                }
                return new ReturnUserProfilePic  { ProfilePicUrl = "/Userimage/" + userProfilePicUrl };
            }
            catch (Exception)
            {
                _customExceptionValidationService.CustomValidation("Something went wrong!", HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<ReturnUserDto> UserProfileUpdate(AddUserDto userDto, string userId)
        {
            if (userDto == null)
            {
                _customExceptionValidationService.CustomValidation("Invalid Request", HttpStatusCode.BadRequest);
            }
            if (userDto.EmailId == null || userDto.Name == null)
            {
                _customExceptionValidationService.CustomValidation("Please pass correct value.", HttpStatusCode.BadRequest);
            }
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(userDto.EmailId);
            if (!match.Success)
            {
                _customExceptionValidationService.CustomValidation("Incorrect EmailId.", HttpStatusCode.BadRequest);
            }
            if (userDto.MobileNo != null) {
                if (userDto.MobileNo.Count() != 10) {
                    _customExceptionValidationService.CustomValidation("Mobile Number is incorrect!", HttpStatusCode.BadRequest);
                }
            }
            bool isValid = Guid.TryParse(userId, out Guid userPublicId);
            if (!isValid)
            {
                _customExceptionValidationService.CustomValidation("Invalid user Id", HttpStatusCode.BadRequest);
            }
            var userData = _userRepository.GetUserByGuid(userPublicId);
            userData.Name = userDto.Name;
            userData.MobileNo = userDto.MobileNo;
            userData.EmailId = userDto.EmailId;
            userData.Address = userDto.Address;
            userData.City = userDto.City;
            userData.PinCode = userDto.PinCode;
            await _userRepository.UpdateUser(userData);
            return new ReturnUserDto { Id = userPublicId };
        }

        /// <summary>
        /// User Registartion
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task<ReturnUserDto> UserRegistartion(RegisterUserDto userDto)
        {
            if (userDto == null)
            {
                _customExceptionValidationService.CustomValidation("Invalid Request", HttpStatusCode.BadRequest);
            }
            if(userDto.EmailId == null || userDto.Password == null || userDto.Name == null)
            {
                _customExceptionValidationService.CustomValidation("Please pass correct value.", HttpStatusCode.BadRequest);
            }
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(userDto.EmailId);
            if (!match.Success)
            {
                _customExceptionValidationService.CustomValidation("Incorrect EmailId.", HttpStatusCode.BadRequest);
            }
            if (userDto.Password.Length < 6) {
                _customExceptionValidationService.CustomValidation("Password length sholuld be more than 6 charector count.", HttpStatusCode.BadRequest);
            }
            var dataIfUserAlreadyExists = _userRepository.GetUserByEmailId(userDto.EmailId);
            if (dataIfUserAlreadyExists != null)
            {
                _customExceptionValidationService.CustomValidation("User Already Exists.", HttpStatusCode.Ambiguous);
            }
            // if OrganizationId is not passed then user will have to be associated with default Organization
            Organization userAssociatedOrganization;
            if (!string.IsNullOrEmpty(userDto.OrgId))
            {
                bool isValid = Guid.TryParse(userDto.OrgId, out Guid orgPublicId);
                if (!isValid)
                {
                    _customExceptionValidationService.CustomValidation("Invalid organization Id", HttpStatusCode.BadRequest);
                }
                userAssociatedOrganization = _organizationRepository.GetOrganizationByPublicId(orgPublicId);
            }
            else {
                userAssociatedOrganization =  _organizationRepository.GetOrganizationById(1).Result;
            }
            var userDbModel = new User
            {
                Name = userDto.Name,
                EmailId = userDto.EmailId,
                Password = Encryptpass(userDto.Password),
                OrganizationId = userAssociatedOrganization.Id,
                ActivationDate = System.DateTime.UtcNow,
                JoiningDate = System.DateTime.UtcNow,
                IsActive = true,
                PublicId = Guid.NewGuid()
            };
            await _userRepository.RegisterUser(userDbModel);
            return await Task.FromResult(new ReturnUserDto { Id = userDbModel.PublicId });
        }
        public string Encryptpass(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }
    }
}