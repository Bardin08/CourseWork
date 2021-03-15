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

        /*public MssqlDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MssqlDbContext(DbContextOptions options) 
            : base(options)
        {
        }*/

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookModel> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-SOHQVE513ER\\SQLEXPRESS;Database=LibraryDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new KeyWordsConfiguration());
        }
    }
}