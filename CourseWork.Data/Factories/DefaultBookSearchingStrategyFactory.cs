using System.Collections.Generic;
using CourseWork.Data.Abstractions;
using CourseWork.Data.Strategies.BookSearchingStrategies;
using CourseWork.Shared.Dtos;

namespace CourseWork.Data.Factories
{
    internal class DefaultBookSearchingStrategyFactory : IBookSearchingStrategyFactory
    {
        public IEnumerable<IBookSearchingStrategy> GetSearchingStrategies(BookSearchingDto bookSearchingDto)
        {
            var searchingStrategies = new List<IBookSearchingStrategy>(bookSearchingDto.SearchingCriteriaAmount);
            
            if (bookSearchingDto.SearchByIsbn) searchingStrategies.Add(new SearchBookByIsbnStrategy()); 
            if (bookSearchingDto.SearchByName) searchingStrategies.Add(new SearchBookByNameStrategy()); 
            if (bookSearchingDto.SearchByPublishYear) searchingStrategies.Add(new SearchBookByPublishYearStrategy());
            if (bookSearchingDto.SearchByAuthor) searchingStrategies.Add(new SearchBookByAuthorStrategy()); 
            if (bookSearchingDto.SearchByKeyWords) searchingStrategies.Add(new SearchBookByKeyWordStrategy());

            return searchingStrategies;
        }
    }
}