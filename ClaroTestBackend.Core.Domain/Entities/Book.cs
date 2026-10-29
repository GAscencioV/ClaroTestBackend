namespace ClaroTestBackend.Core.Domain.Entities
{
    public class Book : AuditableBaseEntity
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int PageCount { get; set; }
        public string? Excerpt { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
