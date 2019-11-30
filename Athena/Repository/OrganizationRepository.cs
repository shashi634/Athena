using Athena.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public Task CreateOrganization(Organization organization)
        {
            return Task.Run(()=> {
                _dbContext.Organization.Add(organization);
                _dbContext.SaveChanges();
            });
        }
        /// <summary>
        /// Get Organization Details
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>Organization</returns>
        public Task<Organization> GetOrganization(Guid organizationId)
        {
            return Task.Run(() => {
                return _dbContext.Organization.FirstOrDefault(x => x.PublicId == organizationId);
            });
        }

        /// <summary>
        /// Update Organization
        /// </summary>
        /// <param name="organization"></param>
        public Task UpdateOrganization(Organization organization)
        {
            return Task.Run(() => {
                _dbContext.Entry(organization).State = EntityState.Modified;
                _dbContext.SaveChanges();
            });
        }
    }
}