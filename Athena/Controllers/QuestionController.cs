using Athena.Models.Dto;
using Athena.Service;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Athena.Controllers
{
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService) {
            _questionService = questionService;
        }
        /// <summary>
        /// Add Question
        /// </summary>
        /// <param name="question"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        [Route("api/Question/{orgId}")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddQuestion(AddQuestionDto question, string orgId)
        {
            var data = await _questionService.AddQuestion(orgId, question);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }
        /// <summary>
        /// Get Question By SubjectId
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [Route("api/Question/{orgId}/{subjectId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuestionBySubjectId(string orgId, string subjectId)
        {
            var data = await _questionService.GetQuestions(orgId, subjectId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        /// <summary>
        /// Get Question For Exam By SubjectId
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [Route("api/Question/Exam/{orgId}/{subjectId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuestionForExamBySubjectId(string orgId, string subjectId)
        {
            var data = await _questionService.Questions(orgId, subjectId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
