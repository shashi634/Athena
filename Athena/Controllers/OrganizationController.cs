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
    public class OrganizationController : ApiController
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService) {
            _organizationService = organizationService;
        }
        [Route("api/Organization/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddOrganization()
        {
            var dto = new OrganizationDto();
            var data = await _organizationService.AddUpdateOrganization(dto);
            return Ok(data);
        }
    }
}
