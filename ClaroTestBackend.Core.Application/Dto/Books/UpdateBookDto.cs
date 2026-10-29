namespace ClaroTestBackend.Core.Application.Dto.Books
{
    public record UpdateBookDto(
        string Title,
        string Description,
        int PageCount,
        string Excerpt,
        DateTime PublishDate
    );
}
