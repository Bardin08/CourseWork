using CourseWork.LogicLayer.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.LogicLayer
{
    public static class DependencyInjection
    {
        public static void UseLogicalLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Abstractions.IBookActionProcessor, DefaultBookActionProcessor>();
        }
    }
}