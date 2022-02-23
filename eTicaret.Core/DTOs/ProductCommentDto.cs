﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class ProductCommentDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
