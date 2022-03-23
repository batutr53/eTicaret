using AutoMapper;
using eTicaret.Core.DTOs;
using eTicaret.Core.Models;
using eTicaret.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public CommentController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }




        [HttpPost]
        public async Task<IActionResult> Save(ProductCommentDto commentDto)
        {
            var comment = await _commentService.AddAsync(_mapper.Map<ProductComment>(commentDto));
            var commentsDto = _mapper.Map<ProductCommentDto>(comment);
            return CreateActionResult(CustomResponseDto<ProductCommentDto>.Success(201, commentsDto));
        }
    }
}
