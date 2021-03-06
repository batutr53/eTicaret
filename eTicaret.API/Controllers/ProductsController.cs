using AutoMapper;
using eTicaret.API.Filters;
using eTicaret.Core;
using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using eTicaret.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetCategoryWithProduct(int categoryId)
        {
            return CreateActionResult(await _productService.GetCategoryWithProduct(categoryId));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchProduct(string productName)
        {
            return CreateActionResult(await _productService.SearchProduct(productName));
        }

        [HttpGet("GetProductWithCategory")]
        //[HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory(string? sort, int page)
        {
            const int pageSize = 5;
            return CreateActionResult(await _productService.GetProductWithCategory(sort, page, pageSize));
        }
      
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("GetProductByIdAll")]
        //[HttpGet("[action]")]
        public async Task<IActionResult> GetProductByIdAll(int productId)
        {
            return CreateActionResult(await _productService.GetProductByIdAll(productId));
        }

        [HttpGet]
      public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIAsync(id);
            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
    }
}
