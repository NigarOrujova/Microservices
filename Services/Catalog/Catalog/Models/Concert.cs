using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CodeAcademy.Catalog.Models;

public class Concert {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Artist { get; set; } = null!;
    public string Location { get; set; }
    public int AvailableTickets { get; set; }
}
