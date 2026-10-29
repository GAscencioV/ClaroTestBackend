using ClaroTestBackend.Core.Application.Dto.Authors;
using ClaroTestBackend.Core.Application.Interfaces;
using ClaroTestBackend.Core.Domain.Entities;
using ClaroTestBackend.Core.Domain.Interfaces.Repositories;

namespace ClaroTestBackend.Core.Application.Services
{
    public class AuthorService : BaseService<Author, AuthorDto, CreateAuthorDto, UpdateAuthorDto>, IAuthorService
    {
        public AuthorService(IAuthorRepository repository) : base(repository)
        {
        }
        protected override Author MapToEntityFromCreate(CreateAuthorDto dto)
        {
            return new Author
            {
                BookId = dto.BookId,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }

        protected override AuthorDto MapToResponseDto(Author entity)
        {
            return new AuthorDto(entity.Id,entity.BookId, entity.FirstName, entity.LastName);
        }

        protected override void UpdateEntityFromDto(Author entity, UpdateAuthorDto dto)
        {
            entity.BookId = dto.BookId;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
        }
    }
}
