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
        Task<ReturnUserDto> UserRegistartion(RegisterUserDto userDto);
        Task<GetUserDto> GetUserByPublicId(string id);
        Task<ReturnUserDto> UserProfileUpdate(AddUserDto userDto, string userId);
        Task<ReturnUserProfilePic> UpdateUserProfilePic(string userId);
    }
}
