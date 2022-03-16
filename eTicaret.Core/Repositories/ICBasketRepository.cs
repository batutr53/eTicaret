using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Repositories
{
    public interface ICBasketRepository
    {
        Task<CBasket> GetBasketAsync(string baskedId);
        Task<CBasket> UpdateBasketAsync(CBasket basked);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
