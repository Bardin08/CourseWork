using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByPublishYearStrategy : Abstractions.IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> books, BookSearchingDto bookSearchingDto)
        {
            return books.Where(book => book.PublishYear == bookSearchingDto.PublishYear);
        }
    }
}