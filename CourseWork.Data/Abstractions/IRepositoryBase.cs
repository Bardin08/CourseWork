using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CourseWork.Data.Abstractions
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll(bool trackChanges);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
        Task<TEntity> FindAsync(string entityId);
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        EntityEntry<TEntity>  Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}