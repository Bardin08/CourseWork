using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByAuthorStrategy : Abstractions.IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> books, BookSearchingDto bookSearchingDto)
        {
            return books.Where(book => book.Author.FirstName
                .Contains(bookSearchingDto.AuthorName) ||
                book.Author.LastName
                .Contains(bookSearchingDto.AuthorName) ||
                (book.Author.FirstName + " " + book.Author.LastName)
                .Contains(bookSearchingDto.AuthorName));
        }
    }
}