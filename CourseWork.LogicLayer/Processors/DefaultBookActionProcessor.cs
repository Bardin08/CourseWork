using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWork.Data.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;
using CourseWork.LogicLayer.Abstractions;
using CourseWork.LogicLayer.Factories;
using CourseWork.LogicLayer.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.LogicLayer.Processors
{
    public class DefaultBookActionProcessor : IBookActionProcessor
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public DefaultBookActionProcessor(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task RemoveBookById(string bookId)
        {
            var modelToDelete = await _bookRepository
                .FindByCondition(b => b.Id == bookId, false)
                .FirstOrDefaultAsync();
            
            _bookRepository.Delete(modelToDelete);
        }

        public async Task UpdateBookById(string bookId, BookCreationDto bookCreationDto)
        {
            var modelToUpdate = await _bookRepository
                .FindByCondition(b => b.Id == bookId, false)
                .FirstOrDefaultAsync();

            if (modelToUpdate == null) return;

            modelToUpdate = bookCreationDto.BookModelFromBookCreationDto();

            var t = _bookRepository.Update(modelToUpdate);
            await _bookRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookModel>> FindBooks(BookSearchingDto bookSearchingDto)
        {
            if (bookSearchingDto == null || bookSearchingDto.SearchingCriteriaAmount == 0)
            {
                return await Task.FromResult(System.Array.Empty<BookModel>());
            }
            
            var searchingStrategies = new DefaultBookSearchingStrategyFactory()
                .GetSearchingStrategies(bookSearchingDto).ToList();

            var books = _bookRepository.FindAll(false)
                .Include(b => b.Author)
                .Include(b => b.KeyWords).AsQueryable();
            
            books = searchingStrategies.Aggregate(books, 
                (current, strategy) => strategy.Execute(current, bookSearchingDto));

            /*
             * This is done to avoid unnecessary List.TrimExcess, if possible.
             * Else TrimExcess would be called and 'books' capacity would be set same as a list size.
             * It requires to revert an unused memory
             */
            if (!books.Any())
            {
                return System.Array.Empty<BookModel>();
            }
            
            books.ToList().TrimExcess();
            
            return books;
        }
    }
}