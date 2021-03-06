using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Services
{
    public interface IUserService:IService<User>
    {
        public Task<CustomResponseDto<UserWithRoleDto>> GetSingleUserByIdWithUserRoleAsync(int userId);
        bool IsUniqueUser(string userName);
        User Authenticate(string userName, string password);
        User Register(string userName, string password);

    }
}
