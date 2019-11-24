using Athena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Athena.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly AthenaVaultContext _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public OrganizationRepository(AthenaVaultContext dbContext) {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<string> GetTestData(string name)
        {
            return Task.Run(() =>
            {
                var data = _dbContext.Subject.FirstOrDefault(x => x.Name == "Physics");
                return data.Name;
            });
        }
    }
}