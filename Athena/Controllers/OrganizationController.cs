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
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationController : ApiController
    {
        private readonly IOrganizationService _organizationService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationService"></param>
        public OrganizationController(IOrganizationService organizationService) {
            _organizationService = organizationService;
        }
        /// <summary>
        /// Create Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [Route("api/Organization/Add")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddOrganization(AddOrganizationDto organization)
        {
            var orgDto = new OrganizationDto { 
            Name = organization.Name,
            Description = organization.Description,
            Address = organization.Address,
            City = organization.City,
            PinCode = organization.PinCode
            };
            var data = await _organizationService.AddUpdateOrganization(orgDto);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }
        /// <summary>
        /// Update Organization
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        [Route("api/Organization/Update/{orgId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateOrganization(string orgId, UpdateOrganizationDto organization)
        {
            var orgDto = new OrganizationDto
            {
                Name = organization.Name,
                Description = organization.Description,
                Address = organization.Address,
                City = organization.City,
                PinCode = organization.PinCode,
                IsActive = organization.IsActive,
                PublicId = orgId
            };
            var data = await _organizationService.AddUpdateOrganization(orgDto);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }
        /// <summary>
        /// Get Organization
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns>OrganizationDto</returns>
        [Route("api/Organization/Get/{orgId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetOrganization(string orgId)
        {
            var data = await _organizationService.GetOrganizationDetails(orgId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
