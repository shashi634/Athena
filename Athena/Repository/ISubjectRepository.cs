using Athena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Repository
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetSubjects();
        Task AddSubject(Subject subject);
        Task UpdateSubjects(Subject subject);
        Subject GetSubjectByPublicId(Guid id);
    }
}
