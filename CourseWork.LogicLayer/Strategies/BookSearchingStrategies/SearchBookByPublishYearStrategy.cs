using System.Linq;
using CourseWork.Domain.Dtos;
using CourseWork.Domain.Models;

namespace CourseWork.LogicLayer.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByPublishYearStrategy : Abstractions.IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> allBooks, BookSearchingDto bookSearchingDto)
        {
            return allBooks.Where(book => book.PublishYear == bookSearchingDto.PublishYear);
        }
    }
}