namespace ClaroTestBackend.Core.Application.Dto.Authors
{
    public record UpdateAuthorDto(
        int BookId,
        string FirstName,
        string LastName
    );
}
