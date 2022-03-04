using eTicaret.Core.Repositories;
using eTicaret.Core.Services;
using eTicaret.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using eTicaret.Repository.Repositories;
namespace eTicaret.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


    

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAync(expression); ;
        }

        public async Task<IEnumerable<T>> GetAllAync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIAsync(int id)
        {
            return await _repository.GetByIAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }


    }
}
