using System.Linq.Expressions;
using app.Repos.Interfaces;
using domain.Entities;
using infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace app.Repos.Implementations
{
    public class CommonRepo<T> : ICommonRepo<T> where T : BaseEntity
    {
        protected readonly WeatherForecastContext DbContext;

        public CommonRepo(WeatherForecastContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = false)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = false)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = false, int skip = 0, int take = 30)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).Skip(skip).Take(take).ToListAsync();
            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = false, int skip = 0, int take = 30)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).Skip(skip).Take(take).ToListAsync();
            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public virtual T AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return entity;
        }

        public virtual void UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }
    }
}
