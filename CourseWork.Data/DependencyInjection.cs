using CourseWork.Data.Contexts;
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
        }

        private static void AddDbContexts(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContextFactory<MssqlDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("LibraryDb")));
            serviceCollection.AddDbContext<ApplicationIdentityDbContext>(options => 
                options.UseSqlite(configuration.GetConnectionString("IdentityDb")));            
        }
    }
}