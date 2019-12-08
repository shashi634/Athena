using Athena.Models.Dto;
using Athena.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
