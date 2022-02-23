using AutoMapper;
using eTicaret.Core.DTOs;
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
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

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
    }
}
