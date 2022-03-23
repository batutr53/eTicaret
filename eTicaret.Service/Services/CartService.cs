using AutoMapper;
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
    public class CartService :Service<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork, IGenericRepository<Cart> repository, ICartRepository cartRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task IniCart(int userId)
        {
            await _cartRepository.AddAsync(new Cart() { UserId = userId});
            _unitOfWork.CommitAsync();
        }

        public async Task<CustomResponseDto<CartByUserIdDto>> GetCartByUserId(int userId)
        {
            var carts = await _cartRepository.GetCartByUserId(userId);
            var cartsDto = _mapper.Map<CartByUserIdDto>(carts);
            return CustomResponseDto<CartByUserIdDto>.Success(200, cartsDto);
        }

        public async Task<CustomResponseDto<CartWithUserDto>> GetCartWithUserId(int userId)
        {
            var carts = await _cartRepository.GetCartByUserId(userId);
            var cartsDto = _mapper.Map<CartWithUserDto>(carts);
            return CustomResponseDto<CartWithUserDto>.Success(200, cartsDto);
        }
    }
}
