using ClaroTestBackend.Core.Domain.Entities;
using ClaroTestBackend.Core.Domain.Interfaces.Repositories;
using ClaroTestBackend.Infrastructure.Persistence.Models.Authors;

namespace ClaroTestBackend.Infrastructure.Persistence.Repositories.HttpClientRepository
{
    public class AuthorRepository : BaseHttpRepository<Author, AuthorResponseDto, AuthorRequestDto>, IAuthorRepository
    {
        public AuthorRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceEndpoint => "Authors";

        protected override Author MapToDomain(AuthorResponseDto dto)
        {
            return new Author 
            { 
                FirstName = dto.FirstName,
                LastName = dto.LastName, 
                BookId = dto.BookId, 
                Id = dto.Id 
            };
        }

        protected override AuthorRequestDto MapToRequest(Author entity)
        {
            return new AuthorRequestDto
            {
                BookId = entity.BookId,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
            };
        }
    }
}
