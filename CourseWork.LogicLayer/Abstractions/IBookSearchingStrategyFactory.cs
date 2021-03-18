using System.Collections.Generic;
using CourseWork.Shared.Dtos;

namespace CourseWork.LogicLayer.Abstractions
{
    internal interface IBookSearchingStrategyFactory
    {
        IEnumerable<IBookSearchingStrategy> GetSearchingStrategies(BookSearchingDto bookSearchingDto);
    }
}