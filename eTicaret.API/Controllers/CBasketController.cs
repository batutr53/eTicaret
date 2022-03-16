using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CBasketController : ControllerBase
    {
        private readonly ICBasketRepository _cbasketRepository;
        public CBasketController(ICBasketRepository cbasketRepository)
        {
            _cbasketRepository = cbasketRepository;
        }

    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
        {
            await _cbasketRepository.DeleteBasketAsync(id);
        }

    [HttpGet]
    public async Task<ActionResult<CBasket>> GetBasketById(string id)
        {
            var basket= await _cbasketRepository.GetBasketAsync(id);
            return Ok(basket??new CBasket(id));
        }

    [HttpPost]
    public async Task<ActionResult<CBasket>> UpdateBasket(CBasket basket) 
        { 
            var updateBasket= await _cbasketRepository.UpdateBasketAsync(basket);
            return Ok(updateBasket);
        }
    }
}
