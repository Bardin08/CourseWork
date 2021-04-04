using CourseWork.Data;
using CourseWork.Data.Contexts;
using CourseWork.LogicLayer;
using CourseWork.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.Configuration.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddApplicationDependencies(this IServiceCollection serviceCollection
            , IConfiguration configuration)
        {
            serviceCollection.AddDataAccessLayer(configuration)
                .AddLogicLayer()
                .AddIdentity()
                .AddMappers();
        } 
        
        private static IServiceCollection AddDataAccessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.UseDataAccessLayer(configuration);
            return serviceCollection;
        }

        private static IServiceCollection AddLogicLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.UseLogicLayer();
            return serviceCollection;
        }

        private static IServiceCollection AddIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDefaultIdentity<IdentityUser>(options => 
                    options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return serviceCollection;
        }

        private static IServiceCollection AddMappers(this IServiceCollection serviceCollection)
        {
            serviceCollection.UseMappers();
            return serviceCollection;
        }
    }
}