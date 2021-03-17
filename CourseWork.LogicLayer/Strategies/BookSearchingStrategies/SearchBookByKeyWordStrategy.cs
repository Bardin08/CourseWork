using System;
using System.Collections.Generic;
using System.Linq;
using CourseWork.Domain.Dtos;
using CourseWork.Domain.Models;

namespace CourseWork.LogicLayer.Strategies.BookSearchingStrategies
{
    internal sealed class SearchBookByKeyWordStrategy : Abstractions.IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> allBooks, BookSearchingDto bookSearchingDto)
        {
            var keyWords = bookSearchingDto.KeyWords.Replace(",", "").Split(" ");

            var books = new List<BookModel>();
            
            /* Do not change the order of cycles! 
             * This variant is the best possible.
             *
             * If we find a word in the book we'll move to a next book
             * else we'll move to the next word for the current book
             */
            foreach (var keyWord in keyWords)
            {
                foreach (var book in allBooks)
                {
                    if (books.Contains(book)) continue;
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