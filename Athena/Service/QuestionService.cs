﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Athena.Models;
using Athena.Models.Dto;
using Athena.Repository;

namespace Athena.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questinRepository;
        private readonly IOrganizationRepository _orgRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ICustomExceptionValidationService _customExceptionValidationService;
        public QuestionService(QuestionRepository questinRepository, ICustomExceptionValidationService customExceptionValidationService, IOrganizationRepository orgRepository, ISubjectRepository subjectRepository) {
            _questinRepository = questinRepository;
            _customExceptionValidationService = customExceptionValidationService;
            _orgRepository = orgRepository;
            _subjectRepository = subjectRepository;
        }
        public async Task<ReturnQuestionDto> AddQuestion(string orgId, AddQuestionDto question)
        {
            try
            {
                bool isOrgValid = Guid.TryParse(orgId, out Guid orgPublicId);
                if (!isOrgValid)
                {
                    _customExceptionValidationService.CustomValidation("Invalid Organization Id.", HttpStatusCode.BadRequest);
                }
                if (question.Question == null || question.Options.Count < 2 || question.SubjectId == null)
                {
                    _customExceptionValidationService.CustomValidation("PLease provide correct data.", HttpStatusCode.BadRequest);
                }
                bool isSubjectValid = Guid.TryParse(question.SubjectId, out Guid subjectPublicId);
                if (!isSubjectValid)
                {
                    _customExceptionValidationService.CustomValidation("Invalid Subject Id.", HttpStatusCode.BadRequest);
                }
                var orgData = _orgRepository.GetOrganizationByPublicId(orgPublicId);
                if (orgData == null)
                {
                    _customExceptionValidationService.CustomValidation("No Organization Registered.", HttpStatusCode.NotFound);
                }
                var subjectdata = _subjectRepository.GetSubjectByPublicId(subjectPublicId);
                if (subjectdata == null)
                {
                    _customExceptionValidationService.CustomValidation("Incorrect Subject.", HttpStatusCode.NotFound);
                }
                var dbQuestionModel = new OrgQuestion
                {
                    Question = question.Question,
                    SubjectId = subjectdata.Id,
                    PublicId = Guid.NewGuid(),
                    CreatedDate = System.DateTime.UtcNow,
                    LastUpdatedDateTime = System.DateTime.UtcNow,
                    OrganizationId = orgData.Id
                };
                var questionOptions = new List<QuestionOption>();
                foreach (var option in question.Options)
                {
                    var q = new QuestionOption
                    {
                        QOption = option.Option,
                        IsCorrect = option.IsCorrect,
                        QuestionId = dbQuestionModel.Id,
                        OrgQuestion = dbQuestionModel,
                        PublicId = Guid.NewGuid()
                    };
                    questionOptions.Add(q);
                }
                dbQuestionModel.QuestionOption = questionOptions;
                await _questinRepository.AddQuestion(dbQuestionModel);
                return new ReturnQuestionDto { QuestionId = dbQuestionModel.PublicId };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<GetQuestionDto>> GetQuestions(string orgId, string subjectid)
        {
            bool isOrgValid = Guid.TryParse(orgId, out Guid orgPublicId);
            if (!isOrgValid)
            {
                _customExceptionValidationService.CustomValidation("Invalid Organization Id.", HttpStatusCode.BadRequest);
            }
            bool isSubjectValid = Guid.TryParse(subjectid, out Guid subjectPublicId);
            if (!isSubjectValid)
            {
                _customExceptionValidationService.CustomValidation("Invalid Subject Id.", HttpStatusCode.BadRequest);
            }
            var orgData = _orgRepository.GetOrganizationByPublicId(orgPublicId);
            if (orgData == null)
            {
                _customExceptionValidationService.CustomValidation("No Organization Registered.", HttpStatusCode.NotFound);
            }
            var subjectdata = _subjectRepository.GetSubjectByPublicId(subjectPublicId);
            if (subjectdata == null)
            {
                _customExceptionValidationService.CustomValidation("Incorrect Subject.", HttpStatusCode.NotFound);
            }
            var getQuestions = _questinRepository.GetOrgQuestionsByOrgGuidAndSubjectId(orgPublicId, subjectPublicId);
            var questionsDto = new List<GetQuestionDto>();
            foreach (var item in getQuestions)
            {
                var x = new GetQuestionDto
                {
                    Question = item.Question,
                    Id = item.PublicId
                };
                var options = new List<GetOptions>();
                foreach (var opt in item.QuestionOption)
                {
                    var k = new GetOptions
                    {
                        Id= opt.PublicId,
                        Option = opt.QOption
                    };
                    options.Add(k);
                }
                x.Options = options;
                questionsDto.Add(x);
            };
            return await Task.FromResult(questionsDto);
        }
    

        public Task<GetQuestionDto> GetQuestionsByQuestionId(string orgId, string questionId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetQuestionOnlyDto>> Questions(string orgId, string subjectid)
        {
            bool isOrgValid = Guid.TryParse(orgId, out Guid orgPublicId);
            if (!isOrgValid)
            {
                _customExceptionValidationService.CustomValidation("Invalid Organization Id.", HttpStatusCode.BadRequest);
            }
            bool isSubjectValid = Guid.TryParse(subjectid, out Guid subjectPublicId);
            if (!isSubjectValid)
            {
                _customExceptionValidationService.CustomValidation("Invalid Subject Id.", HttpStatusCode.BadRequest);
            }
            var orgData = _orgRepository.GetOrganizationByPublicId(orgPublicId);
            if (orgData == null)
            {
                _customExceptionValidationService.CustomValidation("No Organization Registered.", HttpStatusCode.NotFound);
            }
            var subjectdata = _subjectRepository.GetSubjectByPublicId(subjectPublicId);
            if (subjectdata == null)
            {
                _customExceptionValidationService.CustomValidation("Incorrect Subject.", HttpStatusCode.NotFound);
            }
            var getQuestions = _questinRepository.GetOrgQuestionsByOrgGuidAndSubjectId(orgPublicId, subjectPublicId);
            var questionsDto = new List<GetQuestionOnlyDto>();
            foreach (var item in getQuestions)
            {
                var x = new GetQuestionOnlyDto
                {
                    Question = item.Question
                };
                var options = new List<OptionsOnly>();
                foreach (var opt in item.QuestionOption)
                {
                    var k = new OptionsOnly
                    {
                        Option = opt.QOption
                    };
                    options.Add(k);
                }
                x.Options = options;
                questionsDto.Add(x);
            };
            return await Task.FromResult(questionsDto);
        }
    }
}