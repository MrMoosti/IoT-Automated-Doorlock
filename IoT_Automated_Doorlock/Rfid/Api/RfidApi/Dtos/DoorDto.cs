using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rfid.Persistence.Domain;
using Rfid.Persistence.Domain.Enums;

namespace Rfid.Dtos
{
    public class DoorDto
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId BsonObjectId { get; set; }

        [BsonElement("UnixTime")]
        public long UnixTime { get; }

        [BsonElement("Status")]
        public DoorStatus DoorStatus { get; set; }
    }
}