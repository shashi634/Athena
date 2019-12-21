using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Athena.Models;

namespace Athena.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DbContextAthena _dbContext;
        public QuestionRepository(DbContextAthena dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task AddQuestion(OrgQuestion question)
        {
            using (_dbContext)
            {
                _dbContext.OrgQuestion.Add(question);
                foreach (var option in question.QuestionOption)
                {
                    _dbContext.QuestionOption.Add(option);
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<OrgQuestion>> GetOrgQuestionsByOrgGuid(Guid orgId)
        {
            using (_dbContext)
            {
                return await Task.FromResult(_dbContext.OrgQuestion.Where(x => x.Organization.PublicId == orgId));
            }
        }
        public IQueryable<OrgQuestion> GetOrgQuestionsByOrgGuidAndSubjectId(Guid orgId, Guid subjectId)
        {
             return _dbContext.OrgQuestion
                .Where(x => x.Organization.PublicId == orgId && x.Subject.PublicId == subjectId);
        }

        public async Task UpdateQuestion(OrgQuestion question)
        {
            using (_dbContext)
            {
                _dbContext.Entry(question).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}