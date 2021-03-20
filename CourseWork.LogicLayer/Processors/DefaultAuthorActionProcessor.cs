using System.Collections.Generic;
using System.Threading.Tasks;
using CourseWork.Data.Contexts;
using CourseWork.Data.Repositories;
using CourseWork.LogicLayer.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Exceptions;
using CourseWork.Shared.Helpers;
using CourseWork.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.LogicLayer.Processors
{
    public class DefaultAuthorActionProcessor : IAuthorActionProcessor
    {
        private readonly IDbContextFactory<MssqlDbContext> _contextFactory;

        public DefaultAuthorActionProcessor(IDbContextFactory<MssqlDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAuthor(AuthorDto authorDto)
        {
            var userRepository = new AuthorRepository(_contextFactory.CreateDbContext());
            
            await userRepository.CreateAsync(authorDto.AuthorDtoToUserModel());
            await userRepository.SaveChangesAsync();
        }


        public async Task UpdateAuthorById(string authorId, AuthorDto authorDto)
        {
            var userRepository = new AuthorRepository(_contextFactory.CreateDbContext());
            
            userRepository.Update(authorDto.AuthorDtoToUserModel());
            await userRepository.SaveChangesAsync();
        }

        public async Task<AuthorModel> GetAuthorById(string authorId)
        {
            var userRepository = new AuthorRepository(_contextFactory.CreateDbContext());
            var author = await userRepository.FindByCondition(a => a.Id == authorId)
                .FirstOrDefaultAsync();

            if (author == null)
            {
                throw new AuthorNotFoundException($"Author with id: {authorId} not found.");
            }
            return author;
        }
        
        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            var userRepository = new AuthorRepository(_contextFactory.CreateDbContext());
            var authors = await userRepository.FindAll().ToListAsync(); 

            return authors;
        }
    }
}