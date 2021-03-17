using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.Data
{
    public static class DependencyInjection
    {
        public static void UseDataAccessLayer(this IServiceCollection serviceCollection, 
            IConfiguration configuration)
        {
            serviceCollection.AddDbContexts(configuration);
            serviceCollection.AddRepositories();
        }

        private static void AddDbContexts(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<MssqlDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryDb")));
            serviceCollection.AddDbContext<ApplicationIdentityDbContext>(options => 
                options.UseSqlite(configuration.GetConnectionString("IdentityDb")));
        }
        
        private static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}