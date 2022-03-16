using AutoMapper;
using eTicaret.API.Filters;
using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using eTicaret.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        public UsersController(IUserService userService, IMapper mapper, ICartService cartService)
        {
            _userService = userService;
            _mapper = mapper;
            _cartService = cartService;
        }
        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetSingleUserByIdWithUserRoleAsync(int userId)
        {
            return CreateActionResult(await _userService.GetSingleUserByIdWithUserRoleAsync(userId));
        }
       
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAync();
            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserCreateDto userDto)
        {
            var user = await _userService.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserCreateDto>(user);
         //   await _cartService.IniCart(user.Id);
            return CreateActionResult(CustomResponseDto<UserCreateDto>.Success(201, usersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserCreateDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetByIAsync(id);
            await _userService.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
    }
}
