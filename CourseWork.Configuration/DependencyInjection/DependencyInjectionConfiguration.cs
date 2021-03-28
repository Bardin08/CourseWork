using CourseWork.Data;
using CourseWork.Data.Contexts;
using CourseWork.LogicLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.Configuration.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDataAccessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.UseDataAccessLayer(configuration);
        }

        public static void AddLogicLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.UseLogicLayer();
        }

        public static void AddIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDefaultIdentity<IdentityUser>(options => 
                    options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}