using System;
using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByAuthorStrategy : Abstractions.IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> allBooks, BookSearchingDto bookSearchingDto)
        {
            return allBooks.Where(book => book.Author.FirstName
                .Contains(bookSearchingDto.AuthorName) ||
                book.Author.LastName
                .Contains(bookSearchingDto.AuthorName));
        }
    }
}