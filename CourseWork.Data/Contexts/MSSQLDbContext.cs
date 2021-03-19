using CourseWork.Data.Configurations;
using CourseWork.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Contexts
{
    public class MssqlDbContext : DbContext
    {
        public MssqlDbContext(DbContextOptions<MssqlDbContext> options) 
            : base(options)
        {
        }

        public DbSet<AuthorModel> Users { get; set; }
        public DbSet<BookModel> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new KeyWordsConfiguration());
        }
    }
}