using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Athena.Models;
using Athena.Models.Dto;
using Athena.Repository;

namespace Athena.Service
{
    /// <summary>
    /// Subject Service
    /// </summary>
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjetcRepository;
        private readonly ICustomExceptionValidationService _customExceptionValidationService;
        /// <summary>
        /// Organization Service
        /// </summary>
        /// <param name="subjectRepository"></param>
        /// <param name="customExceptionValidationService"></param>
        public SubjectService(ISubjectRepository subjectRepository, ICustomExceptionValidationService customExceptionValidationService)
        {
            _subjetcRepository = subjectRepository;
            _customExceptionValidationService = customExceptionValidationService;
        }
        /// <summary>
        /// Add/Update Subject
        /// </summary>
        /// <param name="addSubjectDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<GetSubjectsDto> AddUpdateSubject(AddSubjectDto addSubjectDto, Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    // add
                    var dbSubjectModel = new Subject
                    {
                        Name = addSubjectDto.SubjectName,
                        PublicId = Guid.NewGuid()
                    };
                    _subjetcRepository.AddSubject(dbSubjectModel);
                    return Task.Run(() =>
                    {
                        return new GetSubjectsDto { Id = dbSubjectModel.PublicId, Subject = dbSubjectModel.Name };
                    });
                }
                else
                {
                    // update
                    var subject = _subjetcRepository.GetSubjectByPublicId(id);
                    if (subject == null)
                    {
                        _customExceptionValidationService.CustomValidation("No Subject", HttpStatusCode.NotFound);
                    }
                    subject.Name = addSubjectDto.SubjectName;
                    _subjetcRepository.UpdateSubjects(subject);
                    return Task.Run(() =>
                    {
                        return new GetSubjectsDto { Id = subject.PublicId, Subject = subject.Name };
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get Subject by Id
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public Task<GetSubjectsDto> GetSubject(string subjectId)
        {
            try
            {
                bool isValid = Guid.TryParse(subjectId, out Guid subjectPublicId);
                if (!isValid)
                {
                    _customExceptionValidationService.CustomValidation("Invalid Subject Id", HttpStatusCode.BadRequest);
                }
                var subject = _subjetcRepository.GetSubjectByPublicId(subjectPublicId);
                if (subject == null) {
                    _customExceptionValidationService.CustomValidation("No Subject", HttpStatusCode.NotFound);
                }
                return Task.Run(() =>
                {
                    return new GetSubjectsDto { Id = subject.PublicId, Subject = subject.Name };
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Subjects
        /// </summary>
        /// <returns></returns>
        public Task<List<GetSubjectsDto>> GetSubjects()
        {
            try
            {
                var subjects = _subjetcRepository.GetSubjects();
                if (subjects.Result == null) {
                    _customExceptionValidationService.CustomValidation("No Subject is yet Added.", HttpStatusCode.NotFound);
                }
                var subjectsDto = new List<GetSubjectsDto>();
                foreach (var subject in subjects.Result)
                {
                    subjectsDto.Add(new GetSubjectsDto { Id = subject.PublicId, Subject = subject.Name }) ;
                }
                return Task.Run(() =>
                {
                    return subjectsDto;
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}