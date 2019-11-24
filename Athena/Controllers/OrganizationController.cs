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
        public async Task<IHttpActionResult> Get()
        {
            var data = await _organizationService.GetHello("shashi shanker singh");
            return Ok(data);
        }
    }
}
