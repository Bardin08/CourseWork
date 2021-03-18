using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Abstractions
{
    internal interface IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> allBooks, BookSearchingDto bookSearchingDto);
    }
}