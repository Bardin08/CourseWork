using System.Collections.Generic;
using CourseWork.Shared.Dtos;

namespace CourseWork.Data.Abstractions
{
    public interface IBookSearchingStrategyFactory
    {
        IEnumerable<IBookSearchingStrategy> GetSearchingStrategies(BookSearchingDto bookSearchingDto);
    }
}