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
    /// <summary>
    /// Subject Controller
    /// </summary>
    public class SubjectController : ApiController
    {
        private readonly ISubjectService _subjectService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectService"></param>
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// Get Subjects
        /// </summary>
        /// <returns>GetSubjectsDto</returns>
        [Route("api/Subjects")]
        [HttpGet]
        public async Task<List<GetSubjectsDto>> GetSubjects() {
           return await _subjectService.GetSubjects();
        }

        /// <summary>
        /// Get Subject by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Subject/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetSubject(string id)
        {
            var data = await _subjectService.GetSubject(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        /// <summary>
        /// Add Subject
        /// </summary>
        /// <param name="addSubjectDto"></param>
        /// <returns>GetSubjectsDto</returns>
        [Route("api/Subject")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddUpdateSubject(AddSubjectDto addSubjectDto) {
            var data = await _subjectService.AddUpdateSubject(addSubjectDto, Guid.Empty);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        /// <summary>
        /// UpdateSubject
        /// </summary>
        /// <param name="addSubjectDto"></param>
        /// <param name="id"></param>
        /// <returns>GetSubjectsDto</returns>
        [Route("api/Subject/{id}")]
        [HttpPut]
        public async Task<HttpResponseMessage> AddUpdateSubject(AddSubjectDto addSubjectDto, Guid id)
        {
            var data =  await _subjectService.AddUpdateSubject(addSubjectDto, id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
