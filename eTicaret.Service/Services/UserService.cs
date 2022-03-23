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
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
           var user = _userRepository.Authenticate(username, password);
            return user;
        }

        public async Task<CustomResponseDto<UserWithRoleDto>> GetSingleUserByIdWithUserRoleAsync(int userId)
        {
            var user = await _userRepository.GetSingleUserByIdWithUserRoleAsync(userId);
            var userDto=_mapper.Map<UserWithRoleDto>(user);
            return CustomResponseDto<UserWithRoleDto>.Success(200, userDto);


        }

        public bool IsUniqueUser(string username)
        {
            return _userRepository.IsUniqueUser(username);
        }

        public User Register(string username, string password)
        {
            var user = _userRepository.Register(username, password);
           _unitOfWork.Commit();
            return user;
        }
    }
}
