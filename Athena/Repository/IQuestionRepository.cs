using Athena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athena.Repository
{
    public interface IQuestionRepository
    {
        Task<IQueryable<OrgQuestion>> GetOrgQuestionsByOrgGuid(Guid orgId);
        Task AddQuestion(OrgQuestion question);
        Task UpdateQuestion(OrgQuestion question);
        Task<IQueryable<OrgQuestion>> GetOrgQuestionsByOrgGuidAndSubjectId(Guid orgId, Guid subjectId);
    }
}
