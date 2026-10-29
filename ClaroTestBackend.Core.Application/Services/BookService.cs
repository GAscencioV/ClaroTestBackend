using ClaroTestBackend.Core.Application.Dto.Books;
using ClaroTestBackend.Core.Application.Interfaces;
using ClaroTestBackend.Core.Domain.Entities;
using ClaroTestBackend.Core.Domain.Interfaces.Repositories;

namespace ClaroTestBackend.Core.Application.Services
{
    public class BookService : BaseService<Book, BookDto, CreateBookDto, UpdateBookDto>, IBookService
    {
        public BookService(IBookRepository repository) : base(repository)
        {
        }
        protected override BookDto MapToResponseDto(Book entity)
        {
            return new BookDto(entity.Id, entity.Title, entity.Description, entity.PageCount, entity.Excerpt, entity.PublishDate);
        }
        protected override Book MapToEntityFromCreate(CreateBookDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Excerpt = dto.Excerpt,
                PageCount = dto.PageCount,
                PublishDate = dto.PublishDate
            };
        }
        protected override void UpdateEntityFromDto(Book entity, UpdateBookDto dto)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Excerpt = dto.Excerpt;
            entity.PageCount = dto.PageCount;
            entity.PublishDate = dto.PublishDate;
        }
    }
}
