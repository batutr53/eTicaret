using AutoMapper;
using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using eTicaret.Core.Services;
using eTicaret.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Service.Services
{
    public class CommentService : Service<ProductComment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork, IGenericRepository<ProductComment> repository, ICommentRepository commentRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
    }
}
