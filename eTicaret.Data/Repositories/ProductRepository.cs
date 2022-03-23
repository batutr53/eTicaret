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


        public async Task<List<Product>> GetProductWithCategory(string? sort,int page,int pageSize)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        return await _context.Products.Include(x => x.Category).
                          Include(x => x.ProductImages).Include(x => x.ProductBrand).OrderBy(x=>x.Price)
                          .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                        break;
                    case "priceDesc":
                        return await _context.Products.Include(x => x.Category).
                          Include(x => x.ProductImages).Include(x => x.ProductBrand).OrderByDescending(x=>x.Price)
                          .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                        break; 
                    case "brand":
                        return await _context.Products.Include(x => x.Category).
                          Include(x => x.ProductImages).Include(x=>x.ProductBrand).OrderByDescending(x=>x.ProductBrandId)
                          .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                        break;
                }
            }
            return await _context.Products.Include(x => x.Category).
               Include(x=>x.ProductImages).Include(x => x.ProductBrand).
               Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<Product>> GetProductByIdAll(int productId)
        {
            return await _context.Products.Where(x => x.Id == productId).Include(x => x.Category)
                         .Include(x => x.ProductFeature).Include(x => x.ProductComments).ThenInclude(xu=>xu.User)
                         .Include(x => x.ProductImages).Include(x => x.ProductBrand).ToListAsync();
        }

        public async Task<List<Product>> SearchProduct(string productName)
        {
            return await _context.Products.Where(x => x.Name.Contains(productName)).ToListAsync();
        }

        public async Task<List<Product>> GetCategoryWithProduct(int categoryId)
        {
            return await _context.Products.Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
