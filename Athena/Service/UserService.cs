using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            var userDetails = _userRepository.GetUserByGuid(userPublicId).FirstOrDefault();
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
            Regex regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$");
            Match match = regex.Match(userDto.EmailId);
            //if (!match.Success) {
            //    _customExceptionValidationService.CustomValidation("Incorrect EmailId.", HttpStatusCode.BadRequest);
            //}
            if (userDto.Password.Length < 6) {
                _customExceptionValidationService.CustomValidation("Password length sholuld be more than 6 charector count.", HttpStatusCode.BadRequest);
            }
            var dataIfUserAlreadyExists = _userRepository.GetUserByEmailId(userDto.EmailId);
            if (dataIfUserAlreadyExists.Count() > 0) {
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
                Password = userDto.Password,
                OrganizationId = userAssociatedOrganization.Id,
                ActivationDate = System.DateTime.UtcNow,
                JoiningDate = System.DateTime.UtcNow,
                IsActive = true,
                PublicId = Guid.NewGuid()
            };
            await _userRepository.RegisterUser(userDbModel);
            return await Task.FromResult(new ReturnUserDto { Id = userDbModel.PublicId });
        }
    }
}