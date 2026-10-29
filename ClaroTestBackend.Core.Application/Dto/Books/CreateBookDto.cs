namespace ClaroTestBackend.Core.Application.Dto.Books
{
    public record CreateBookDto(
        string Title,
        string Description,
        int PageCount,
        string Excerpt,
        DateTime PublishDate
    );
}
