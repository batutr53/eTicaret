using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketAsync(string baskedId);
        Task<Basket> UpdateBasketAsync(Basket basked);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
