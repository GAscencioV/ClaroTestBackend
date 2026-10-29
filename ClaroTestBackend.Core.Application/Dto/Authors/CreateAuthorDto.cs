namespace ClaroTestBackend.Core.Application.Dto.Authors
{
    public record CreateAuthorDto(
        int BookId,
        string FirstName,
        string LastName
    );
}
