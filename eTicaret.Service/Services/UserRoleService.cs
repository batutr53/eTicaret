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
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork, IGenericRepository<UserRole> repository) : base(unitOfWork, repository)
        {
        }
    }
}
