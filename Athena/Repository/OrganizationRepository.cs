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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<string> GetTestData(string name)
        {
            return Task.Run(() =>
            {
                return "Hello "+ name;
            });
        }
    }
}