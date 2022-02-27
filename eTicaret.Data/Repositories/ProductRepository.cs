using eTicaret.Core;
using eTicaret.Core.DTOs;
using eTicaret.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace eTicaret.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<List<Product>> GetProductWithCategory()
        {
            return await _context.Products.Include(x => x.Category).Include(x=>x.ProductFeature).Include(x=>x.ProductComments).Include(x=>x.ProductImages).ToListAsync();
        }

      

    }
}
