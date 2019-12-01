using Athena.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        Task<Guid> UserRegistartion(AddUserDto userDto);
        Task<GetUserDto> GetUserByPublicId(string id);
    }
}
