using System.Linq;
using CourseWork.Domain.Dtos;
using CourseWork.Domain.Models;

namespace CourseWork.LogicLayer.Abstractions
{
    internal interface IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> allBooks, BookSearchingDto bookSearchingDto);
    }
}