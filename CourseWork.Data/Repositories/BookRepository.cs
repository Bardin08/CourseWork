using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Domain.Models;

namespace CourseWork.Data.Repositories
{
    public class BookRepository : RepositoryBase<BookModel, MssqlDbContext>, IBookContext
    {
        public BookRepository(MssqlDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}