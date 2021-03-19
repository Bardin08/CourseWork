using System.Collections.Generic;
using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.Shared.Helpers
{
    public static class MappingHelper
    {
        public static AuthorDto AuthorModelToAuthorDto(this UserModel authorModel)
        {
            return new AuthorDto
            {
                Id = authorModel.Id,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };
        }
        
        public static UserModel AuthorDtoToUserModel(this AuthorDto authorDto)
        {
            return new UserModel
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
                ISBN = bookDto.Isbn
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
                KeyWordsString = bookModel.KeyWords.KeyWordsListToString(),
                Isbn = bookModel.ISBN,
                AuthorName = bookModel.Author.FirstName + " " + bookModel.Author.LastName
            };
        }
        
        private static string KeyWordsListToString(this IEnumerable<KeyWordModel> keyWords)
        {
            var words = keyWords.Select(word => (string) word).ToList();
            return string.Join(',', words);
        }
    }
}