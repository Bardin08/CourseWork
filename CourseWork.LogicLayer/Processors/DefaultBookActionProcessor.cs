using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWork.Data.Contexts;
using CourseWork.Data.Repositories;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;
using CourseWork.LogicLayer.Abstractions;
using CourseWork.LogicLayer.Factories;
using CourseWork.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.LogicLayer.Processors
{
    public class DefaultBookActionProcessor : IBookActionProcessor
    {
        private readonly IDbContextFactory<MssqlDbContext> _contextFactory;

        public DefaultBookActionProcessor(IDbContextFactory<MssqlDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateBook(BookDto bookDto)
        {
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext());
            await bookRepository.CreateAsync(bookDto.BookModelFromBookDto());
            await bookRepository.SaveChangesAsync();
            bookRepository.Dispose();
        }

        public async Task RemoveBookById(string bookId)
        {
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext());
            
            var bookToRemove = await bookRepository.FindByCondition(b => b.Id == bookId)
                .Include(b => b.Author)
                .Include(b => b.KeyWords).AsQueryable().FirstOrDefaultAsync();

            if (bookToRemove != null)
            {
                bookRepository.Delete(bookToRemove);
                await bookRepository.SaveChangesAsync();
            }
        }
        
        public async Task UpdateBookById(string bookId, BookDto bookDto)
        {
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext());

            var oldModel = await bookRepository.FindByCondition(b => b.Id == bookId)
                .Include(b => b.Author)
                .Include(b => b.KeyWords)
                .FirstOrDefaultAsync();

            var updateModel = bookDto.BookModelFromBookDto();

            oldModel.Name = updateModel.Name;
            oldModel.Isbn = updateModel.Isbn;
            oldModel.Description = updateModel.Description;
            oldModel.PublishYear = updateModel.PublishYear;
            oldModel.Author.FirstName = updateModel.Author.FirstName;
            oldModel.Author.LastName = updateModel.Author.LastName;
            //oldModel.KeyWords.Add(new KeyWordModel {Id = Guid.NewGuid().ToString(), Word = "F"});

            var keyWordModels = updateModel.KeyWords.Where(kw =>
            {
                return oldModel.KeyWords.All(okw => kw.Word != okw.Word);
            }).ToList();
            oldModel.KeyWords.AddRange(keyWordModels);

            keyWordModels = oldModel.KeyWords.Where(kw =>
            {
                return updateModel.KeyWords.All(okw => kw.Word != okw.Word);
            }).ToList();
            keyWordModels.ForEach(kw => oldModel.KeyWords.Remove(kw));
            
            bookRepository.Update(oldModel);
            await bookRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookModel>> GetBooks(BookSearchingDto bookSearchingDto)
        {
            if (bookSearchingDto == null || bookSearchingDto.SearchingCriteriaAmount == 0)
            {
                return await Task.FromResult(System.Array.Empty<BookModel>());
            }
         
            var bookRepository = new BookRepository(_contextFactory.CreateDbContext());
            
            var searchingStrategies = new DefaultBookSearchingStrategyFactory()
                .GetSearchingStrategies(bookSearchingDto).ToList();

            var books = bookRepository.FindAll(false)
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