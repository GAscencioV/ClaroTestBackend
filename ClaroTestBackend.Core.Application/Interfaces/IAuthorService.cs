using ClaroTestBackend.Core.Application.Dto.Authors;

namespace ClaroTestBackend.Core.Application.Interfaces
{
    public interface IAuthorService : IBaseService<AuthorDto, CreateAuthorDto, UpdateAuthorDto>
    {
    }
}
