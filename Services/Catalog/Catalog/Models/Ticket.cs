

namespace CodeAcademy.Catalog.Models;

public class Ticket {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string? Description { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }

    public string? Picture { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedDate { get; set; }





    /* Navigation Properties */
    public string? UserId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string ConcertId { get; set; }

    [BsonIgnore] // db icerisinde yer almayacak
    public Concert Concert { get; set; } 
}