using System.Collections.Generic;
using System.Linq;

namespace CourseWork.Data.Abstractions
{
    public interface ISearchingFilter<T>
    {
        public IEnumerable<T> Filter(IQueryable<T> enumerable);
    }
}