using AutoMapper;
using eTicaret.Core;
using eTicaret.Core.DTOs;
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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IProductRepository productRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithAllDto>>> GetProductByIdAll(int productId)
        {
            var products = await _productRepository.GetProductByIdAll(productId);
            var productsDto = _mapper.Map<List<ProductWithAllDto>>(products);
            return CustomResponseDto<List<ProductWithAllDto>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<List<ProductWithAllDto>>> GetProductWithCategory(string? sort, int page, int pageSize)
        {
            var products = await _productRepository.GetProductWithCategory(sort, page, pageSize);
            var productsDto = _mapper.Map<List<ProductWithAllDto>>(products);
            return CustomResponseDto<List<ProductWithAllDto>>.Success(200, productsDto);
        }
    }
}
