using System.Text.Json.Serialization;

namespace ClaroTestBackend.Infrastructure.Persistence.Models.Authors
{
    public class AuthorRequestDto
    {
        [JsonPropertyName("idBook")]
        public int BookId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;
    }
}
