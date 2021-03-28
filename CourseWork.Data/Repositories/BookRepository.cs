using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Shared.Models;

namespace CourseWork.Data.Repositories
{
    public class BookRepository : RepositoryBase<BookModel, ApplicationDbContext>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}