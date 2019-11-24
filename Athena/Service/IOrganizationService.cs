using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Service
{
    public interface IOrganizationService
    {
        Task<string> GetHello(string name);
    }
}
