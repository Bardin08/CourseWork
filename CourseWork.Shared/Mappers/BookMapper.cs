using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Mappers.Abstractions;
using CourseWork.Shared.Models;

namespace CourseWork.Shared.Mappers
{
    public class BookMapper : IBookMapper
    {
        public BookDto MapTo(BookModel input)
        {
            return new()
            {
                Id = input.Id,
                Author = input.Author,
                BookName = input.Name,
                PublishYear = input.PublishYear,
                Description = input.Description,
                KeyWordModels = input.KeyWords,
                KeyWordsString = string.Join(", ", input.KeyWords.Select(w => w.Word)),
                Isbn = input.Isbn,
                AuthorName = input.Author.FirstName + " " + input.Author.LastName
            };
        }

        public BookModel MapFrom(BookDto input)
        {
            return new()
            {
                Id = input.Id,
                Author = input.Author,
                Name = input.BookName,
                PublishYear = input.PublishYear,
                Description = input.Description,
                KeyWords = input.KeyWordModels,
                Isbn = input.Isbn
            };        
        }

        public BookModel MapWithExisting(BookModel current, BookModel updated)
        {
            current.Name = updated.Name;
            current.Description = updated.Description;
            current.Isbn = updated.Isbn;
            current.PublishYear = updated.PublishYear;

            current.Author.FirstName = updated.Author.FirstName;
            current.Author.LastName = updated.Author.LastName;
            
            // words which should be added
            var keyWordModels =
                updated.KeyWords.Where(kw => current.KeyWords.All(okw => kw.Word != okw.Word));
            current.KeyWords.AddRange(keyWordModels);

            // words which should be removed
            keyWordModels = 
                current.KeyWords.Where(kw => updated.KeyWords.All(okw => kw.Word != okw.Word));
            keyWordModels.ToList().ForEach(kw => current.KeyWords.Remove(kw));

            return current;
        }
    }
}