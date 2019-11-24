using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Repository
{
    public interface IOrganizationRepository
    {
        Task<string> GetTestData(string name);
    }
}
