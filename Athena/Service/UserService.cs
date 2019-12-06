using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Athena.Models.Dto;

namespace Athena.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : IUserService
    {
        public Task<GetUserDto> GetUserByPublicId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UserRegistartion(AddUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}