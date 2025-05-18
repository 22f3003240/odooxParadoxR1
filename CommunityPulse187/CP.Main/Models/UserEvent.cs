using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CP.Main.Models
{
    public class UserEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("mapId")]
        public string MapId { get; set; }

        [BsonElement("user_Id")]
        public string UserId { get; set; }

        [BsonElement("event_Id")]
        public string EventId { get; set; }

    }
}