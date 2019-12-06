using Athena.Models;
using Athena.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Repository
{
    public interface IUserRepository
    {
        Task RegisterUser(User registerUser);
        Task UpdateUser(User updateUser);
        IQueryable<User> GetUserByGuid(Guid id);
    }
}
