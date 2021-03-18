using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Shared.Models;

namespace CourseWork.Data.Repositories
{
    public class BookRepository : RepositoryBase<BookModel, MssqlDbContext>, IBookRepository
    {
        public BookRepository(MssqlDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}