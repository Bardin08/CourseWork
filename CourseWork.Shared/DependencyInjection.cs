using CourseWork.Shared.Mappers;
using CourseWork.Shared.Mappers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.Shared
{
    public static class DependencyInjection
    {
        public static void UseMappers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBookMapper, BookMapper>();
        }
    }
}