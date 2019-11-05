using MongoDB.Bson.Serialization.Attributes;
using Rfid.Persistence.Domain.Enums;

namespace Rfid.Persistence.Domain.Collections
{

    public class Door : BaseBsonDocument
    {
        [BsonElement("Status")]
        public DoorStatus DoorStatus { get; set; }
    }
}
