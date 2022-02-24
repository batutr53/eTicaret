using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class ProductImageDto
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }
        public int ProductId { get; set; }
    }
}
