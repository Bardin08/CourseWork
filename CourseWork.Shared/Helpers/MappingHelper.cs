﻿using System;
using System.Collections.Generic;
using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Shared.Helpers
{
    public static class MappingHelper
    {
        public static AuthorDto AuthorDtoFromAuthorModel(this AuthorModel authorModel)
        {
            return new AuthorDto
            {
                Id = authorModel.Id,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };
        }
        
        public static AuthorModel AuthorModelFromAuthorDto(this AuthorDto authorDto)
        {
            return new AuthorModel
            {
                Id = authorDto.Id,
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName
            };
        }
        
        public static BookModel BookModelFromBookDto(this BookDto bookDto)
        {
            return new BookModel
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

        public static BookDto BookDtoFromBookModel(this BookModel bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Author = bookModel.Author,
                BookName = bookModel.Name,
                PublishYear = bookModel.PublishYear,
                Description = bookModel.Description,
                KeyWordModels = bookModel.KeyWords,
                KeyWordsString = bookModel.KeyWords.KeywordsStringFromKeywordModelsList(),
                Isbn = bookModel.Isbn,
                AuthorName = bookModel.Author.FirstName + " " + bookModel.Author.LastName
            };
        }

        public static List<KeyWordModel> KeywordModelsListFromKeywordsString(this string keywords)
        {
            var words = keywords.Replace(",", "").Split(" ");
            return words.Select(word =>
                new KeyWordModel {Id = Guid.NewGuid().ToString(), Word = word}).ToList();
        }
        
        private static string KeywordsStringFromKeywordModelsList(this IEnumerable<KeyWordModel> keyWords)
        {
            var words = keyWords.Select(word => (string) word).ToList();
            return string.Join(", ", words);
        }
    }
}