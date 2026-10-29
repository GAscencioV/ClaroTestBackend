using ClaroTestBackend.Core.Domain.Entities;
using ClaroTestBackend.Core.Domain.Interfaces.Repositories;
using ClaroTestBackend.Infrastructure.Persistence.Models.Books;

namespace ClaroTestBackend.Infrastructure.Persistence.Repositories.HttpClientRepository
{
    public class BookRepository : BaseHttpRepository<Book, BookResponseDto, BookRequestDto>, IBookRepository
    {
        public BookRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceEndpoint => "Books";

        protected override Book MapToDomain(BookResponseDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Excerpt = dto.Excerpt,
                Id = dto.Id,
                PageCount = dto.PageCount,
                PublishDate = dto.PublishDate,
            };
        }

        protected override BookRequestDto MapToRequest(Book entity)
        {
            return new BookRequestDto
            {
                Title = entity.Title,
                PublishDate = entity.PublishDate,
                PageCount = entity.PageCount,
                Excerpt = entity.Excerpt,
                Description = entity.Description
            };
        }
    }
}
