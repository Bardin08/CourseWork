using System.Threading.Tasks;
using CourseWork.Data.Abstractions;
using CourseWork.Data.Configurations;
using CourseWork.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Contexts
{
    public class MssqlDbContext : DbContext
    {
        private readonly string _connectionString;

        public MssqlDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookModel> Books { get; set; }

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