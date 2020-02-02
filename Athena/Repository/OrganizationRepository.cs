using Athena.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task CreateOrganization(Organization organization)
        {
            using (_dbContext)
            {
                _dbContext.Organization.Add(organization);
                await _dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Get Organization Details
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>Organization</returns>
        public async Task<Organization> GetOrganization(Guid organizationId)
        {
            using (_dbContext)
            {
                return await Task.FromResult(
                 _dbContext.Organization.FirstOrDefault(x => x.PublicId == organizationId)
                );
            }
        }
        /// <summary>
        /// Get Organization By PublicId
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        public Organization GetOrganizationByPublicId(Guid publicId)
        {
           return _dbContext.Organization.FirstOrDefault(x => x.PublicId == publicId);
        }

        /// <summary>
        /// Update Organization
        /// </summary>
        /// <param name="organization"></param>
        public async Task UpdateOrganization(Organization organization)
        {
            using (_dbContext)
            {
                _dbContext.Entry(organization).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// GetOrganizationById (Numeric)
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task<Organization> GetOrganizationById(int organizationId)
        {
            return await Task.FromResult(
                 _dbContext.Organization.FirstOrDefault(x => x.Id == organizationId)
            );
        }
    }
}