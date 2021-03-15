using System.Threading.Tasks;
using CourseWork.Data.Abstractions;
using CourseWork.Data.Configurations;
using CourseWork.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Contexts
{
    public class MssqlDbContext : DbContext, IDbContext
    {
        private readonly string _connectionString;

        public MssqlDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookModel> Books { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            base.Update(entity);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new KeyWordsConfiguration());
        }
    }
}