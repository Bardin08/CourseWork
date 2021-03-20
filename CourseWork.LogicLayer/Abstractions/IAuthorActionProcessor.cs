using System.Threading.Tasks;
using CourseWork.Shared.Dtos;

namespace CourseWork.LogicLayer.Abstractions
{
    public interface IAuthorActionProcessor
    {
        Task UpdateAuthor(AuthorDto authorDto);
    }
}