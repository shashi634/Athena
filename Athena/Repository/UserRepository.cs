using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Athena.Models;

namespace Athena.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextAthena _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public UserRepository(DbContextAthena dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByEmailId(string emailId)
        {
            return _dbContext.User.Where(x => x.EmailId == emailId).FirstOrDefault();
        }

        /// <summary>
        /// Get User By Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserByGuid(Guid id)
        {
             return _dbContext.User.Where(x => x.PublicId == id).FirstOrDefault();
        }
        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        public async Task RegisterUser(User registerUser)
        {
            using (_dbContext)
            {
                _dbContext.User.Add(registerUser);
                await _dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        public async Task UpdateUser(User updateUser)
        {
            using (_dbContext)
            {
                _dbContext.Entry(updateUser).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}