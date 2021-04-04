using System.Collections.Generic;
using System.Threading.Tasks;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Data.Abstractions
{
    public interface IBookRepository : IRepositoryBase<BookModel>
    {
        public IEnumerable<BookModel> GetAllBooks();
        public Task RemoveBookById(string id);
        public Task CreateBook(BookModel bookModel);
        public Task UpdateBookById(BookModel updatedBook);
        public Task<IEnumerable<BookModel>> SelectBooksAsync(BookSearchingDto bookSearchingDto);
    }
}