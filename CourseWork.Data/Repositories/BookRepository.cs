using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Data.SearchingFilters;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Mappers.Abstractions;
using CourseWork.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Repositories
{
    public class BookRepository : RepositoryBase<BookModel, ApplicationDbContext>, IBookRepository
    {
        private readonly IBookMapper _bookMapper;
        private readonly IBookSearchingStrategyFactory _searchingStrategyFactory;

        public BookRepository(ApplicationDbContext context, 
            IBookMapper bookMapper, 
            IBookSearchingStrategyFactory searchingStrategyFactory) 
            : base(context)
        {
            _bookMapper = bookMapper;
            _searchingStrategyFactory = searchingStrategyFactory;
        }

        public async Task CreateBook(BookModel bookModel)
        {
            await CreateAsync(bookModel);
            await SaveChangesAsync();
        }
        
        public async Task RemoveBookById(string id)
        {
            var bookToRemove = await FindByCondition(b => b.Id == id, false)
                .Include(b => b.Author)
                .Include(b => b.KeyWords).FirstOrDefaultAsync();

            if (bookToRemove != null)
            {
                Delete(bookToRemove);
                await SaveChangesAsync();
            }
        }
        
        public async Task UpdateBookById(BookModel updatedBook)
        {
            var existingBook = await FindByCondition(b => b.Id == updatedBook.Id, true)
                .Include(b => b.Author)
                .Include(b => b.KeyWords)
                .FirstOrDefaultAsync();
            
            _bookMapper.MapWithExisting(existingBook, updatedBook);            

            Update(existingBook);
            await SaveChangesAsync();
        }
        
        public IEnumerable<BookModel> GetAllBooks()
        {
            return FindAll(false);
        }
        
        public async Task<IEnumerable<BookModel>> SelectBooksAsync(BookSearchingDto bookSearchingDto)
        {
            var books = FindAll(false)
                .Include(b => b.Author)
                .Include(b => b.KeyWords).AsQueryable();

            var booksFilter = 
                new BooksFilter(_searchingStrategyFactory.GetSearchingStrategies(bookSearchingDto), bookSearchingDto);
            return await Task.FromResult(booksFilter.Filter(books));
        }
    }
}