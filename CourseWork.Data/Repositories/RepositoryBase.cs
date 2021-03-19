using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CourseWork.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CourseWork.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> 
        :IRepositoryBase<TEntity>, IDisposable
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;

        protected RepositoryBase(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> FindAll(bool trackChanges = true)
        {
            return trackChanges
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = true)
        {
            return trackChanges
                ? _context.Set<TEntity>().Where(expression)
                : _context.Set<TEntity>().AsNoTracking().Where(expression);
        }

        public Task<TEntity> FindAsync(string entityId)
        {
            return _context.Set<TEntity>().FindAsync(entityId).AsTask();
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public Task CreateAsync(TEntity entity)
        {
            return _context.Set<TEntity>().AddAsync(entity).AsTask();
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}