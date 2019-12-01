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
        public Task AddSubject(Subject subject)
        {
            return Task.Run(() => {
                _dbContext.Subject.Add(subject);
                _dbContext.SaveChanges();
            });
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
        public Task<List<Subject>> GetSubjects()
        {
            return Task.Run(() => {
                return _dbContext.Subject.ToList();
            });
        }
        /// <summary>
        /// Update Subjects
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public Task UpdateSubjects(Subject subject)
        {
            return Task.Run(() => {
                _dbContext.Entry(subject).State = EntityState.Modified;
                _dbContext.SaveChanges();
            });
        }
    }
}