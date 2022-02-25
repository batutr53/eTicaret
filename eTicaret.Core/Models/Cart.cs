using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class Cart
    {
        private List<Cartline> _cartLines = new List<Cartline>();
        public List<Cartline> Cartlines { get { return _cartLines; } }

        public void AddProduct(Product product, int quantity)
        { 
        var line = _cartLines.FirstOrDefault(x=>x.Product.Id==product.Id);
            if (line == null)
            {
                _cartLines.Add(new Cartline() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(x=>x.Product.Id==product.Id);
        }
        public double Total()
        {
            return (double)_cartLines.Sum(x => x.Product.Price * x.Quantity);
        }

        public void Clear()
        { 
            _cartLines.Clear(); 
        }
    }

    public class Cartline
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
