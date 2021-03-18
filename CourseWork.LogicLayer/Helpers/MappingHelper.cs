using System.Collections.Generic;
using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Helpers
{
    internal static class MappingHelper
    {
        public static BookModel BookModelFromBookCreationDto(this BookCreationDto bookDto)
        {
            return new BookModel
            {
                Id = bookDto.Id,
                Name = bookDto.BookName,
                Author = bookDto.Author,
                PublishYear = bookDto.PublishYear,
                Description = bookDto.Description,
                KeyWords = bookDto.KeyWordModels,
                ISBN = bookDto.Isbn
            };
        }

        private static List<KeyWordModel> StringToKeyWordsList(this string keywords)
        {
            new List<char> {',', '.', ':', ';', '-', '!', '?'}
                .ForEach(delimiter =>
                {
                    keywords = keywords.Replace(delimiter, ' ');
                });

            var keywordsArray = keywords.Split(' ');

            return keywordsArray
                .Select(kw => new KeyWordModel {Id = System.Guid.NewGuid().ToString(), Word = kw})
                .ToList();
        }
    }
}