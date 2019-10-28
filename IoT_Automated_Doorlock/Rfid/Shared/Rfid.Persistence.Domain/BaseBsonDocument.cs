using System;
using System.Reflection.Metadata;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rfid.Persistence.Domain
{

    public class BaseBsonDocument
    {

        /// <summary>
        /// Creates a new <see cref="BaseBsonDocument"/>
        /// </summary>
        public BaseBsonDocument()
        {
            UnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            BsonObjectId = ObjectId.GenerateNewId();
        }


        /// <summary>
        /// The <see cref="ObjectId"/> of the document.
        /// </summary>
        [BsonId]
        [BsonElement("_id")]
        public ObjectId BsonObjectId { get; set; }


        /// <summary>
        /// The <see cref="UnixTime"/> of when the <see cref="Document"/> was added to the collection.
        /// </summary>
        [BsonElement("UnixTime")]
        public long UnixTime { get; set; }
    }
}
