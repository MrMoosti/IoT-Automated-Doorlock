using System;
using System.Reflection.Metadata;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rfid.Persistence.Domain
{

    public class BaseBsonDocument
    {
        public BaseBsonDocument()
        {
            UnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            BsonObjectId = ObjectId.GenerateNewId();
        }

        [BsonId]
        [BsonElement("_id")]
        public ObjectId BsonObjectId { get; set; }

        [BsonElement("UnixTime")]
        public long UnixTime { get; set; }
    }
}
