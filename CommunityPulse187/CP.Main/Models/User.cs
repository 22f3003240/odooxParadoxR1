using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CP.Main.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("user_id")]
        public string UserId { get; set; } = string.Empty;

        [BsonElement("user_name")]
        public string UserName { get; set; } = string.Empty;

        [BsonElement("contact")]
        public string Contact { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("is_admin")]
        public bool IsAdmin { get; set; }
    }
}
