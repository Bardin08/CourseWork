using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Data.Factories;
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
            serviceCollection.AddDbContextFactory<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("LibraryDb")));
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryDb")));
            serviceCollection.AddScoped<IBookSearchingStrategyFactory, DefaultBookSearchingStrategyFactory>();
        }
    }
}