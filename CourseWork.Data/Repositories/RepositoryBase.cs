using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CourseWork.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> 
        :IRepositoryBase<TEntity> 
        where TEntity : class
        where TContext : DbContext
    {
        public RepositoryBase(TContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public TContext RepositoryContext { get; private set; }
        
        public IQueryable<TEntity> FindAll(bool trackChanges = true)
        {
            return trackChanges
                ? RepositoryContext.Set<TEntity>()
                : RepositoryContext.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = true)
        {
            return trackChanges
                ? RepositoryContext.Set<TEntity>().Where(expression)
                : RepositoryContext.Set<TEntity>().AsNoTracking().Where(expression);
        }

        public Task<TEntity> FindAsync(int entityId)
        {
            return RepositoryContext.Set<TEntity>().FindAsync(entityId).AsTask();
        }

        public void Create(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Add(entity);
        }

        public Task CreateAsync(TEntity entity)
        {
            return RepositoryContext.Set<TEntity>().AddAsync(entity).AsTask();
        }

        public void Update(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return RepositoryContext.SaveChangesAsync();
        }
    }
}