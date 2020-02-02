using Athena.Models;
using System;
using System.Threading.Tasks;

namespace Athena.Repository
{
    public interface IUserRepository
    {
        Task RegisterUser(User registerUser);
        Task UpdateUser(User updateUser);
        User GetUserByGuid(Guid id);
        User GetUserByEmailId(string emailId);
    }
}
