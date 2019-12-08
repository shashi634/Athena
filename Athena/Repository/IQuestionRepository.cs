using Athena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Repository
{
    public interface IQuestionRepository
    {
        Task<IQueryable<List<OrgQuestion>>> GetOrgQuestionsByOrgGuid(Guid orgId);
    }
}
