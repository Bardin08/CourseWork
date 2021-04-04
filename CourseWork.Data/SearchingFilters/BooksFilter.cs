using System.Collections.Generic;
using System.Linq;
using CourseWork.Data.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Data.SearchingFilters
{
    public class BooksFilter : ISearchingFilter<BookModel>
    {
        private readonly IEnumerable<IBookSearchingStrategy> _searchingStrategies;
        private readonly BookSearchingDto _bookSearchingDto;
        
        public BooksFilter(IEnumerable<IBookSearchingStrategy> searchingStrategies, BookSearchingDto bookSearchingDto)
        {
            _searchingStrategies = searchingStrategies;
            _bookSearchingDto = bookSearchingDto;
        }
        
        public IEnumerable<BookModel> Filter(IQueryable<BookModel> books)
        {
            return _searchingStrategies
                .Aggregate(books, (current, s) => s.Execute(current, _bookSearchingDto));
        }
    }
}