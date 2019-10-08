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

        [BsonElement("AddedAtUtc")]
        public BsonDateTime AddedAtUtc { get; }

        [BsonElement("Status")]
        public DoorStatus DoorStatus { get; set; }
    }
}