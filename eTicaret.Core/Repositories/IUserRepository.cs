using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetSingleUserByIdWithUserRoleAsync(int userId);

        bool IsUniqueUser(string username);
        User Authenticate(string username, string password);
        User Register(string username, string password);
    }
}
