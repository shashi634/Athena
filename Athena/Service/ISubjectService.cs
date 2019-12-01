using Athena.Models.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athena.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubjectService
    {
        Task<List<GetSubjectsDto>> GetSubjects();
        Task<GetSubjectsDto> GetSubject(string Guid);
        Task<GetSubjectsDto> AddUpdateSubject(AddSubjectDto addSubjectDto, Guid id);
    }
}
