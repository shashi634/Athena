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
        public async Task<IHttpActionResult> AddOrganization(OrganizationDto organization)
        {
            var data = await _organizationService.AddUpdateOrganization(organization);
            return Ok(data);
        }

        /// <summary>
        /// Get Organization
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns>OrganizationDto</returns>
        [Route("api/Organization/Get/{orgId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOrganization(Guid orgId)
        {
            var data = await _organizationService.GetOrganizationDetails(orgId);
            return Ok(data);
        }
    }
}
