using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CP.Main.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("event_id")]
        public string EventId { get; set; }

        [BsonElement("event_name")]
        public string EventName { get; set; }

        [BsonElement("organiser")]
        public string Organiser { get; set; }

        [BsonElement("event_date")]
        public DateTime EventDate { get; set; }

        [BsonElement("geo_location")]
        public GeoLocation GeoLocation { get; set; }
    }

    public class GeoLocation
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("coordinates")]
        public double[] Coordinates { get; set; }
    }
}