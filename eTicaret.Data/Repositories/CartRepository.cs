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
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
        }

     

       public async Task<Cart> GetCartByUserId(int userId)
        {
            return await _context.Carts.Include(i => i.CartItems).ThenInclude(i=>i.Product).FirstOrDefaultAsync(i => i.UserId == userId);
        }

        public async Task<Cart> GetCartWithUserId(int userId)
        {
               return await _context.Carts.Include(i => i.CartItems).ThenInclude(i=>i.Product).FirstOrDefaultAsync(i => i.UserId == userId);
        }
    }
}
