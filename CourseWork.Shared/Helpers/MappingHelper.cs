using System;
using System.Collections.Generic;
using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Shared.Helpers
{
    public static class MappingHelper
    {
        public static AuthorDto ToAuthorDto(this AuthorModel authorModel)
        {
            return new()
            {
                Id = authorModel.Id,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };
        }
        
        public static AuthorModel ToAuthorModel(this AuthorDto authorDto)
        {
            return new()
            {
                Id = authorDto.Id,
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName
            };
        }
        
        public static BookDto ToBookDto(this BookModel bookModel)
        {
            return new()
            {
                Id = bookModel.Id,
                Author = bookModel.Author,
                BookName = bookModel.Name,
                PublishYear = bookModel.PublishYear,
                Description = bookModel.Description,
                KeyWordModels = bookModel.KeyWords,
                KeyWordsString = bookModel.KeyWords.ToKeywordsString(),
                Isbn = bookModel.Isbn,
                AuthorName = bookModel.Author.FirstName + " " + bookModel.Author.LastName
            };
        }
        
        public static BookModel ToBookModel(this BookDto bookDto)
        {
            return new()
            {
                Id = bookDto.Id,
                Author = bookDto.Author,
                Name = bookDto.BookName,
                PublishYear = bookDto.PublishYear,
                Description = bookDto.Description,
                KeyWords = bookDto.KeyWordModels,
                Isbn = bookDto.Isbn
            };
        }

        public static List<KeyWordModel> ToKeywordModelsList(this string keywords)
        {
            var words = keywords.Replace(",", "").Split(" ");
            return words.Select(word =>
                new KeyWordModel {Id = Guid.NewGuid().ToString(), Word = word}).ToList();
        }
        
        private static string ToKeywordsString(this IEnumerable<KeyWordModel> keyWords)
        {
            var words = keyWords.Select(word => (string) word).ToList();
            return string.Join(", ", words);
        }
    }
}