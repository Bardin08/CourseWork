using System.Threading.Tasks;
using CourseWork.Data.Contexts;
using CourseWork.Data.Repositories;
using CourseWork.LogicLayer.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.LogicLayer.Processors
{
    public class DefaultAuthorActionProcessor : IAuthorActionProcessor
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public DefaultAuthorActionProcessor(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public async Task UpdateAuthor(AuthorDto authorDto)
        {
            var userRepository = new AuthorRepository(_contextFactory.CreateDbContext());
            
            userRepository.Update(authorDto.ToAuthorModel());
            await userRepository.SaveChangesAsync();
        }
    }
}