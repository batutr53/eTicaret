using eTicaret.Core.Models;
using eTicaret.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Repository.Repositories
{
    public class CommentRepository : GenericRepository<ProductComment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
