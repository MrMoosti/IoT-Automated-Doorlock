using MongoDB.Bson.Serialization.Attributes;
using Rfid.Persistence.Domain.Enums;

namespace Rfid.Persistence.Domain.Collections
{

    public class Log : BaseBsonDocument
    {

        /// <summary>
        /// The Uid of <see cref="Log"/>
        /// </summary>
        [BsonElement("Uid")]
        public byte[] Uid { get; set; }


        /// <summary>
        /// The <see cref="AttemptType"/> of this <see cref="Log"/>
        /// </summary>
        [BsonElement("Type")]
        public AttemptType AttemptType { get; set; }


        /// <summary>
        /// The message of this <see cref="Log"/>.
        /// </summary>
        [BsonElement("Message")]
        public string Message { get; set; }
    }
}
