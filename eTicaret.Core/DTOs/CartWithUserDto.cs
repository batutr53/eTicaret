using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class CartWithUserDto: CartDto
    {
        public CartItemDto CartItems { get; set; }
    }
}
