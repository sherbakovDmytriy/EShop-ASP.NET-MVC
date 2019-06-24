using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly DbContext _context;
        readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        #region Get

        public async Task<IEnumerable<TEntity>> Get(int? limit = null)
        {
            if (limit.HasValue)
            {
                return await _dbSet
                    .Take(limit.Value)
                    .ToListAsync();
            }

            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetWithInclude(int? limit = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (limit.HasValue)
            {
                return await Include(includeProperties)
                    .Take(limit.Value)
                    .ToListAsync();
            }

            return await Include(includeProperties)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhereWithInclude(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> FirstWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties)
                .FirstOrDefaultAsync();
        }

        #endregion

        #region CRUD

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        #endregion

        #region Private methods

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #endregion
    }
}