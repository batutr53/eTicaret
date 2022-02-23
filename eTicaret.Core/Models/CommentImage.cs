using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class CommentImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCommentId { get; set; }
        public ProductComment ProductComment { get; set; }

    }
}
