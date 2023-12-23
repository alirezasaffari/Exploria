using System.Linq.Expressions;
using app.Repos.Interfaces;
using app.Services.Interfaces;
using domain.Entities;

namespace app.Services.Implementations
{
    public class CommonService<T> : ICommonService<T> where T : BaseEntity
    {
        private readonly ICommonRepo<T> _repository;

        public CommonService(ICommonRepo<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public virtual async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = false)
        {
            return await _repository.GetFirstAsync(predicate, orderBy, includeString, disableTracking);
        }

        public virtual async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = false)
        {
            return await _repository.GetFirstAsync(predicate, orderBy, includes, disableTracking);
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = false)
        {
            return await _repository.GetAsync(predicate, orderBy, includeString, disableTracking);
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = false)
        {
            return await _repository.GetAsync(predicate, orderBy, includes, disableTracking);
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual T AddAsync(T entity)
        {
            return _repository.AddAsync(entity);
        }

        public virtual void UpdateAsync(T entity)
        {
            _repository.UpdateAsync(entity);
        }

        public virtual void DeleteAsync(T entity)
        {
            _repository.DeleteAsync(entity);
        }
    }
}
