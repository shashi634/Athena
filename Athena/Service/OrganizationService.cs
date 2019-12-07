using Athena.Models.Dto;
using Athena.Repository;
using System;
using System.Threading.Tasks;
using System.Net;
using Athena.Models;

namespace Athena.Service
{
    /// <summary>
    /// Organization Service
    /// </summary>
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICustomExceptionValidationService _customExceptionValidationService;
        /// <summary>
        /// Organization Service
        /// </summary>
        /// <param name="organizationRepository"></param>
        /// <param name="customExceptionValidationService"></param>
        public OrganizationService(IOrganizationRepository organizationRepository, ICustomExceptionValidationService customExceptionValidationService) {
            _organizationRepository = organizationRepository;
            _customExceptionValidationService = customExceptionValidationService;
        }

        /// <summary>
        /// Add/Update Organization
        /// </summary>
        /// <param name="organizationDto"></param>
        /// <returns>Guid</returns>
        public async Task<ReturnOrganizationDto> AddUpdateOrganization(OrganizationDto organizationDto)
        {
            try
            {
                if (string.IsNullOrEmpty(organizationDto.Name))
                {
                    _customExceptionValidationService.CustomValidation("Organization Name is missing", HttpStatusCode.BadRequest);
                }
                if (string.IsNullOrEmpty(organizationDto.Address))
                {
                    _customExceptionValidationService.CustomValidation("Organization Address is missing", HttpStatusCode.BadRequest);
                }
                if (string.IsNullOrEmpty(organizationDto.City))
                {
                    _customExceptionValidationService.CustomValidation("Organization City is missing", HttpStatusCode.BadRequest);
                }
                if (organizationDto.PinCode == null || organizationDto.PinCode == 0)
                {
                    _customExceptionValidationService.CustomValidation("Organization PinCode is missing", HttpStatusCode.BadRequest);
                }
                if (organizationDto.PublicId == null)
                {
                    // add
                    var organizationDBModel = new Organization 
                    {
                        PublicId = Guid.NewGuid(),
                        Name = organizationDto.Name,
                        Address = organizationDto.Address,
                        City = organizationDto.City,
                        PinCode = organizationDto.PinCode,
                        Description = organizationDto.Description,
                        IsActive = false,
                        JoiningDate = DateTime.UtcNow,
                    };
                    await _organizationRepository.CreateOrganization(organizationDBModel);
                    return new ReturnOrganizationDto { OrganizationId = (Guid)organizationDBModel.PublicId };
                }
                else
                {
                    // update
                    bool isValid = Guid.TryParse(organizationDto.PublicId, out Guid orgPublicId);
                    if (!isValid)
                    {
                        _customExceptionValidationService.CustomValidation("Organization Id is invalid", HttpStatusCode.BadRequest);
                    }
                    var orgDetails = _organizationRepository.GetOrganizationByPublicId(orgPublicId);
                    if (orgDetails == null)
                    {
                        _customExceptionValidationService.CustomValidation("Organization Not Found", HttpStatusCode.NotFound);
                    }
                    orgDetails.Name = organizationDto.Name;
                    orgDetails.Description = organizationDto.Description;
                    orgDetails.Address = organizationDto.Address;
                    orgDetails.PinCode = organizationDto.PinCode;
                    orgDetails.IsActive = organizationDto.IsActive;
                    if (organizationDto.IsActive)
                    {
                        orgDetails.ActivationDate = DateTime.UtcNow;
                    }
                    await _organizationRepository.UpdateOrganization(orgDetails);
                    return new ReturnOrganizationDto { OrganizationId = orgPublicId };
                }
                
            }
            catch (Exception ex)
            {
               _customExceptionValidationService.CustomValidation(ex.Message, HttpStatusCode.InternalServerError);
                throw;
            }
        }

        /// <summary>
        /// Get Organization Details
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public async Task<GetOrganizationDto> GetOrganizationDetails(string orgId)
        {
            if (orgId == null)
            {
                _customExceptionValidationService.CustomValidation("Organization Id is invalid", HttpStatusCode.BadRequest);
            }
            bool isValid = Guid.TryParse(orgId, out Guid guidOutput);
            if (!isValid) {
                _customExceptionValidationService.CustomValidation("Organization Id is invalid", HttpStatusCode.BadRequest);
            }
            var orgDetails = _organizationRepository.GetOrganization(guidOutput);
            if (orgDetails.Result == null) {
                _customExceptionValidationService.CustomValidation("Organization Not Found", HttpStatusCode.NotFound);
            }
            var data = new GetOrganizationDto
            {
                Name = orgDetails.Result.Name,
                Address = orgDetails.Result.Address,
                City = orgDetails.Result.City,
                PinCode = orgDetails.Result.PinCode,
                Description = orgDetails.Result.Description,
                IsActive = orgDetails.Result.IsActive,
                JoiningDate = orgDetails.Result.JoiningDate,
                ActivationDate = orgDetails.Result.ActivationDate
            };
            return await Task.FromResult(data);
        }
    }
}