﻿using System.Linq;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.LogicLayer.Abstractions
{
    public interface IBookSearchingStrategy
    {
        public IQueryable<BookModel> Execute(IQueryable<BookModel> books, BookSearchingDto bookSearchingDto);
    }
}