using System.Text.Json.Serialization;

namespace ClaroTestBackend.Infrastructure.Persistence.Models.Books
{
    public class BookRequestDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("pageCount")]
        public int PageCount { get; set; }
        [JsonPropertyName("excerpt")]
        public string Excerpt { get; set; } = string.Empty;
        [JsonPropertyName("publishDate")] 
        public DateTime PublishDate { get; set; }
    }
}
