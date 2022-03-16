using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eTicaret.Repository.Repositories
{
    public class CBasketRepository : ICBasketRepository
    {
        private readonly IDatabase _database;
        public CBasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CBasket> GetBasketAsync(string baskedId)
        {
            var data=await _database.StringGetAsync(baskedId);
            return data.IsNullOrEmpty?null:JsonSerializer.Deserialize<CBasket>(data);
        }

        public async Task<CBasket> UpdateBasketAsync(CBasket basket)
        {
            var update = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
            if (!update) return null;
            return await GetBasketAsync(basket.Id)
;        }
    }
}
