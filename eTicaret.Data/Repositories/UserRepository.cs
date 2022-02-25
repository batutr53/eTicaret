using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<User> GetSingleUserByIdWithUserRoleAsync(int userId)
        {
          return await _context.Users.Include(x=>x.UserRole).Include(x => x.Addresses).Where(x=>x.Id == userId).SingleOrDefaultAsync();        
        }
    }
}