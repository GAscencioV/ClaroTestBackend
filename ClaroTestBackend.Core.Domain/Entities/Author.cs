namespace ClaroTestBackend.Core.Domain.Entities
{
    public class Author : AuditableBaseEntity
    {
        public int BookId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
