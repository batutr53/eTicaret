using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Repositories
{
    public interface ICartRepository:IGenericRepository<Cart>
    {
       Task<Cart> GetCartByUserId(int userId);
       Task<Cart> GetCartWithUserId(int userId);
    }
}
