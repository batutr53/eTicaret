using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }

    [HttpGet]
    public async Task<ActionResult<Basket>> GetBasketById(string id)
        {
        var basket= await _basketRepository.GetBasketAsync(id);
            return Ok(basket??new Basket(id));
        }

    [HttpPost]
    public async Task<ActionResult<Basket>> UpdateBasket(Basket basket) 
        { 
            var updateBasket= await _basketRepository.UpdateBasketAsync(basket);
            return Ok(updateBasket);
        }
    }
}
