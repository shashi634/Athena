using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        /// <summary>
        /// GetUserByGuid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<User> GetUserByGuid(Guid id)
        {
            IQueryable<User> user = _dbContext.User.Where(x => x.PublicId == id);
            return user;
        }
        /// <summary>
        /// RegisterUser
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        public async Task RegisterUser(User registerUser)
        {
            _dbContext.User.Add(registerUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}