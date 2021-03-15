using CourseWork.Data.Abstractions;
using CourseWork.Data.Contexts;
using CourseWork.Domain.Models;

namespace CourseWork.Data.Repositories
{
    public class UserRepository : RepositoryBase<UserModel, MssqlDbContext>, IUserRepository
    {
        public UserRepository(MssqlDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}