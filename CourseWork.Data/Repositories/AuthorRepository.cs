using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Shared.Models;

namespace CourseWork.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<AuthorModel, ApplicationDbContext>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}