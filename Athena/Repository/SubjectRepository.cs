using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Athena.Models;

namespace Athena.Repository
{
    /// <summary>
    /// Subject Repository
    /// </summary>
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DbContextAthena _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public SubjectRepository(DbContextAthena dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Add Subject
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public async Task AddSubject(Subject subject)
        {
            _dbContext.Subject.Add(subject);
            await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Get Subject By PublicId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Subject GetSubjectByPublicId(Guid id)
        {
            return _dbContext.Subject.FirstOrDefault(x => x.PublicId == id);
        }
        /// <summary>
        /// Get Subjects
        /// </summary>
        /// <returns></returns>
        public async Task<List<Subject>> GetSubjects()
        {
            return await Task.FromResult(_dbContext.Subject.ToList());
        }
        /// <summary>
        /// Update Subjects
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public async Task UpdateSubjects(Subject subject)
        {
            _dbContext.Entry(subject).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}