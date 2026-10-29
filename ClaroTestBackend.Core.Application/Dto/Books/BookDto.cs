namespace ClaroTestBackend.Core.Application.Dto.Books
{
    public record BookDto(
        int Id,
        string Title,
        string Description,
        int PageCount,
        string Excerpt,
        DateTime PublishDate
    );
}
