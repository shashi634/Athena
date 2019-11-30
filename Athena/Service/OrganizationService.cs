using Athena.Models.Dto;
using Athena.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public async Task<Guid> AddUpdateOrganization(OrganizationDto organizationDto)
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
                        JoiningDate = System.DateTime.UtcNow,
                    };
                    await _organizationRepository.CreateOrganization(organizationDBModel);
                    return (Guid)organizationDBModel.PublicId;
                }
                else
                {
                    // update
                }
                return Guid.NewGuid();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Organization Details
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public Task<GetOrganizationDto> GetOrganizationDetails(Guid orgId)
        {
            var orgDetails = _organizationRepository.GetOrganization(orgId);
            return Task.Run(()=> {
                return new GetOrganizationDto { 
                Name = orgDetails.Result.Name,
                Address = orgDetails.Result.Address,
                City = orgDetails.Result.City,
                PinCode = orgDetails.Result.PinCode,
                Description = orgDetails.Result.Description,
                IsActive = orgDetails.Result.IsActive,
                JoiningDate = orgDetails.Result.JoiningDate,
                };
            });
        }
    }
}