using System.Collections.Generic;
using CourseWork.Domain.Dtos;

namespace CourseWork.LogicLayer.Abstractions
{
    internal interface IBookSearchingStrategyFactory
    {
        IEnumerable<IBookSearchingStrategy> GetSearchingStrategies(BookSearchingDto bookSearchingDto);
    }
}