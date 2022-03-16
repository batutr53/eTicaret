using eTicaret.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class CartByUserIdDto:CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
    }
 
}
