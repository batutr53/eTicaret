using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class CBasket
    {
        public CBasket()
        {

        }
        public CBasket(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<CBasketItem> BasketItems { get; set; } = new List<CBasketItem>();
    }
}
