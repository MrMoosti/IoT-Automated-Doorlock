using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rfid.Persistence.Domain.Enums;

namespace Rfid.Persistence.Domain.Collections
{

    public class Log : BaseBsonDocument
    {
        [BsonElement("Uid")]
        public byte[] Uid { get; set; }

        [BsonElement("Type")]
        public AttemptType AttemptType { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }
    }
}
