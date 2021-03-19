using System;
using System.Collections.Generic;
using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByKeyWordStrategy : Abstractions.IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> allBooks, BookSearchingDto bookSearchingDto)
        {
            var keyWords = bookSearchingDto.KeyWordsString.Replace(",", "").Split(" ");

            var books = new List<BookModel>();
            
            foreach (var book in allBooks)
            {
                foreach (var keyWord in keyWords)
                {
                    if (books.Contains(book)) break;
                    if (book.KeyWords.Any(word => 
                        word.Word.Contains(keyWord, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        books.Add(book);
                    }
                }
            }

            return books.AsQueryable();
        }
    }
}