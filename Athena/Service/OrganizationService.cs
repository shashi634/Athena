using Athena.Models.Dto;
using Athena.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;

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
                if (organizationDto.PublicId == null)
                {
                    // add
                    if (string.IsNullOrEmpty(organizationDto.Name))
                    {
                        _customExceptionValidationService.CustomValidation("", HttpStatusCode.BadRequest);
                    }
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

        public Task<OrganizationDto> GetOrganizationDetails(Guid orgId)
        {
            throw new NotImplementedException();
        }
    }
}