using Athena.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Athena.Service
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository) {
            _organizationRepository = organizationRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<string> GetHello(string name)
        {
            return _organizationRepository.GetTestData(name);
        }
    }
}