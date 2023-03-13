namespace Catalog.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string? Picture { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public string? UserId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = null!;
        [BsonIgnore]
        public Category Category { get; set; } = null!;
        public BookInfo? BookInfo { get; set; }
    }
}
