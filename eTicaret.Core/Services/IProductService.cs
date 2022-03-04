using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithAllDto>>> GetProductWithCategory(string? sort, int page, int pageSize);
        Task<CustomResponseDto<List<ProductWithAllDto>>> GetProductByIdAll(int productId);
      
    }
}
