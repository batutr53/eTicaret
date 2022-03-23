using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using eTicaret.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppSettings _appSettings;
        public UserRepository(AppDbContext context,IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings=appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokendDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                         new Claim(ClaimTypes.Name,user.Id.ToString()),
                         new Claim(ClaimTypes.Role,user.UserRoleId.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(
                         new SymmetricSecurityKey(key),
                         SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokendDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";
            return user;
        }

        public async Task<User> GetSingleUserByIdWithUserRoleAsync(int userId)
        {
          return await _context.Users.Include(x=>x.UserRole).Include(x => x.UserAddresses).Where(x=>x.Id == userId).SingleOrDefaultAsync();        
        }

        public bool IsUniqueUser(string username)
        {
           var user = _context.Users.SingleOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public User Register(string username, string password)
        {
            User user = new User()
            {
                UserName = username,
                Password = password,
                UserRoleId = 3,
                Confirmation=true
            };
            _context.Users.Add(user);
            return user;
        }
    }
}