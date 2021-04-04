using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Data.Repositories;
using CourseWork.Data.SearchingFilters;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;
using CourseWork.LogicLayer.Abstractions;
using CourseWork.Shared.Helpers;
using CourseWork.Shared.Mappers.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.LogicLayer.Processors
{
    public class DefaultBookActionProcessor : IBookActionProcessor
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IBookSearchingStrategyFactory _searchingStrategyFactory;
        private readonly IBookMapper _bookMapper;

        public DefaultBookActionProcessor(IDbContextFactory<ApplicationDbContext> contextFactory, 
            IBookSearchingStrategyFactory searchingStrategyFactory, 
            IBookMapper bookMapper)
        {
            _contextFactory = contextFactory;
            _searchingStrategyFactory = searchingStrategyFactory;
            _bookMapper = bookMapper;
        }
        
        public async Task CreateBook(BookDto bookDto)
        {
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext(),
                _bookMapper, _searchingStrategyFactory);
            await bookRepository.CreateBook(_bookMapper.MapFrom(bookDto));
        }

        public async Task RemoveBookById(string bookId)
        {
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext(), 
                _bookMapper, _searchingStrategyFactory);
            await bookRepository.RemoveBookById(bookId);
        }
        
        public async Task UpdateBookById(string bookId, BookDto bookDto)
        {
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext(),
                _bookMapper, _searchingStrategyFactory);
            await bookRepository.UpdateBookById(_bookMapper.MapFrom(bookDto));
        }
        
        public async Task<IEnumerable<BookModel>> GetBooks(BookSearchingDto bookSearchingDto)
        {
            if (bookSearchingDto == null || bookSearchingDto.SearchingCriteriaAmount == 0)
            {
                return await Task.FromResult(System.Array.Empty<BookModel>());
            }
         
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext(),
                _bookMapper, _searchingStrategyFactory);
            return await bookRepository.SelectBooksAsync(bookSearchingDto); 
        }
    }
}