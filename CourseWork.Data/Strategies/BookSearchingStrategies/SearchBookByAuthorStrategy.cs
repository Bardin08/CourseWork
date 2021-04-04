using System.Linq;
using CourseWork.Data.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Data.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByAuthorStrategy : IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> books, BookSearchingDto bookSearchingDto)
        {
            return books.Where(book => book.Author.FirstName.Contains(bookSearchingDto.Author.FirstName) ||
                book.Author.LastName.Contains(bookSearchingDto.Author.LastName) ||
                (book.Author.FirstName + " " + book.Author.LastName).Contains(bookSearchingDto.AuthorName));
        }
    }
}