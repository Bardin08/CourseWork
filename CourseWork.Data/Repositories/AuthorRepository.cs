﻿using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<AuthorModel, MssqlDbContext>, IAuthorRepository
    {
        public AuthorRepository(MssqlDbContext context) : base(context)
        {
        }
    }
}