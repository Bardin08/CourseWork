using System.Collections.Generic;
using System.Threading.Tasks;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Abstractions
{
    public interface IBookActionProcessor
    {
        Task CreateBook(BookDto bookDto);
        Task RemoveBookById(string bookId);
        Task UpdateBookById(string bookId, BookDto bookDto);
        Task<IEnumerable<BookModel>> FindBooks(BookSearchingDto bookSearchingDto);
        Task<IEnumerable<BookModel>> FindAllBooks();
    }
}