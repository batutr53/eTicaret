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
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CustomResponseDto<UserWithRoleDto>> GetSingleUserByIdWithUserRoleAsync(int userId)
        {
            var user = await _userRepository.GetSingleUserByIdWithUserRoleAsync(userId);
            var userDto=_mapper.Map<UserWithRoleDto>(user);
            return CustomResponseDto<UserWithRoleDto>.Success(200, userDto);


        }

  
    }
}
