using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CourseWork.Data.Abstractions;
using CourseWork.Domain.Dtos;
using CourseWork.Domain.Models;
using CourseWork.LogicLayer.Factories;

namespace CourseWork.LogicLayer.Processors
{
    public class BookSearchingProcessor
    {
        private readonly IBookRepository _bookRepository;

        public BookSearchingProcessor(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookModel> FindBooks(BookSearchingDto bookSearchingDto)
        {
            if (bookSearchingDto == null || bookSearchingDto.SearchingCriteriaAmount == 0)
            {
                return System.Array.Empty<BookModel>();
            }
            
            var searchingStrategies = new DefaultBookSearchingStrategyFactory()
                .GetSearchingStrategies(bookSearchingDto).ToList();

            var books = _bookRepository.FindAll(false)
                .Include(b => b.Author)
                .Include(b => b.KeyWords).AsQueryable();

            var booksList = books.ToList();
            
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