using Athena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Athena.Repository
{
    /// <summary>
    /// Organization Repository 
    /// </summary>
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DbContextAthena _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public OrganizationRepository(DbContextAthena dbContext) {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Create Update Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public void CreateUpdateOrganization(Organization organization)
        {
           _dbContext.Organization.Add(organization);
           _dbContext.SaveChanges();
        }
        /// <summary>
        /// Get Organization Details
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>Organization</returns>
        public Organization GetOrganization(Guid organizationId)
        {
            return _dbContext.Organization.FirstOrDefault(x => x.PublicId == organizationId);
        }
    }
}