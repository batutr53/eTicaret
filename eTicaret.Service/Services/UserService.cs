using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using eTicaret.Core.Services;
using eTicaret.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> repository) : base(unitOfWork, repository)
        {
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public User Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
