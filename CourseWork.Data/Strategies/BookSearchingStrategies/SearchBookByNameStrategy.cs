using System.Linq;
using CourseWork.Data.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Data.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByNameStrategy : IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> books, BookSearchingDto bookSearchingDto)
        {
            return books.Where(book => book.Name
                .Contains(bookSearchingDto.BookName));
        }
    }
}