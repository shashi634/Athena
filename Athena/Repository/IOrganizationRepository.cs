using Athena.Models;
using System;
using System.Threading.Tasks;

namespace Athena.Repository
{
    /// <summary>
    /// IOrganizationRepository
    /// </summary>
    public interface IOrganizationRepository
    {
        /// <summary>
        /// Create Update Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        
        void CreateUpdateOrganization(Organization organization);
        /// <summary>
        /// Get Organization
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>Organization</returns>
        Organization GetOrganization(Guid organizationId);
    }
}
