namespace Lovie.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("battery")]
    public int Battery { get; set; }

    [BsonElement("isDigirecorder")]
    public bool IsDigirecorder { get; set; }
}