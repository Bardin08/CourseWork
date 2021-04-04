using System;
using System.Collections.Generic;
using System.Linq;
using CourseWork.Data.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Data.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByKeyWordStrategy : IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> books, BookSearchingDto bookSearchingDto)
        {
            var keyWords = bookSearchingDto.KeyWordsString.Replace(",", "").Split(" ");
            var suitableBooks = new List<BookModel>();
            
            foreach (var book in books)
            {
                foreach (var keyWord in keyWords)
                {
                    if (suitableBooks.Contains(book)) break;
                    if (book.KeyWords.Any(word => 
                        word.Word.Contains(keyWord, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        suitableBooks.Add(book);
                    }
                }
            }

            return suitableBooks.AsQueryable();
        }
    }
}