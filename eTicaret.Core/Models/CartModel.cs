using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItem { get; set; }
    }

    public class CartItemModel 
    {

        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }

    }
}
