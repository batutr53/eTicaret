using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.DTOs
{
    public class ProductWithAllDto:ProductDto
    {
        public CategoryDto Category { get; set; }
        public ProductFeatureDto ProductFeature { get; set; }
        public List<ProductCommentDto> ProductComments { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
        public List<CommentImageDto> CommentImages { get; set; }
        public ProductBrandDto ProductBrand { get; set; }

    }
}
