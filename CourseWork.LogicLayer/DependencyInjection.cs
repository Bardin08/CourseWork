using CourseWork.LogicLayer.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.LogicLayer
{
    public static class DependencyInjection
    {
        public static void UseLogicLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Abstractions.IBookActionProcessor, DefaultBookActionProcessor>();
            serviceCollection.AddScoped<Abstractions.IAuthorActionProcessor, DefaultAuthorActionProcessor>();
        }
    }
}