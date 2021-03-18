using System.Collections.Generic;
using System.Threading.Tasks;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Abstractions
{
    public interface IBookActionProcessor
    {
        Task RemoveBookById(string bookId);
        Task UpdateBookById(string bookId, BookCreationDto bookCreationDto);
        Task<IEnumerable<BookModel>> FindBooks(BookSearchingDto bookSearchingDto);
    }
}