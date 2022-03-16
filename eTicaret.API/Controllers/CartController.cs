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
    public class CartController : CustomBaseController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

     
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetCartByUserId(int userId)
        {
            var cart = await _cartService.GetCartByUserId(userId);
            return CreateActionResult(cart);

        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetCartWithUserId(int userId)
        {
            var cart = await _cartService.GetCartWithUserId(userId);
            return CreateActionResult(cart);

        }
    }
}
