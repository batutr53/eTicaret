using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class ProductComment
    {
        public int Id { get; set; }
        public string Comment { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; } = false;
        public List<CommentImage> CommentImages { get; set; }

    }
}
