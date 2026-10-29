using ClaroTestBackend.Core.Application.Dto.Books;

namespace ClaroTestBackend.Core.Application.Interfaces
{
    public interface IBookService : IBaseService<BookDto, CreateBookDto, UpdateBookDto>
    {
    }
}
