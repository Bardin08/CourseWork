using CourseWork.LogicLayer.Abstractions;
using CourseWork.LogicLayer.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.LogicLayer
{
    public static class DependencyInjection
    {
        public static void UseLogicLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBookActionProcessor, DefaultBookActionProcessor>();
            serviceCollection.AddScoped<IAuthorActionProcessor, DefaultAuthorActionProcessor>();
        }
    }
}