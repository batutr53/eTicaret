using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Services
{
    public interface ICartService:IService<Cart>
    {
        Task IniCart(int userId);
        Task<CustomResponseDto<CartByUserIdDto>> GetCartByUserId(int userId);
        Task<CustomResponseDto<CartWithUserDto>> GetCartWithUserId(int userId);
    }
}
