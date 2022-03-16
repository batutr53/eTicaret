using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductWithCategory(string? sort,int page,int pageSize);
        Task<List<Product>> GetProductByIdAll(int productId);
        Task<List<Product>> SearchProduct(string productName);
        Task<List<Product>> GetCategoryWithProduct(int categoryId);
    }
}
