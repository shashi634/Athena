using Athena.Models.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athena.Service
{
    public interface IQuestionService
    {
        Task<ReturnQuestionDto> AddQuestion(string orgId, AddQuestionDto question);
        Task<List<GetQuestionDto>> GetQuestions(string orgId, string subjectid);
        Task<GetQuestionDto> GetQuestionsByQuestionId(string orgId, string questionId);
        Task<List<GetQuestionOnlyDto>> Questions(string orgId, string subjectid);
    }
}
