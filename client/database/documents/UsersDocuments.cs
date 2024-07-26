using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class UserDocument
{
    [BsonId]
    public string? _id { get; set; }

    [BsonElement("money")]
    public int money { get; set; } = 0;
}