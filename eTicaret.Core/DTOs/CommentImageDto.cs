using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class CommentImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCommentId { get; set; }
    }
}
