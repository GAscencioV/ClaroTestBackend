namespace ClaroTestBackend.Core.Application.Dto.Authors
{
    public record AuthorDto(
        int Id,
        int BookId,
        string FirstName,
        string LastName
    );
}
