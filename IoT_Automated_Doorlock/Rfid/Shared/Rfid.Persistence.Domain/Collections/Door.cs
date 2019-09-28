using MongoDB.Bson.Serialization.Attributes;
using Rfid.Persistence.Domain.Enums;

namespace Rfid.Persistence.Domain.Collections
{

    public class Door : BaseBsonDocument
    {

        /// <summary>
        /// The <see cref="DoorStatus"/> of this <see cref="Door"/>
        /// </summary>
        [BsonElement("Status")]
        public DoorStatus DoorStatus { get; set; }
    }
}
