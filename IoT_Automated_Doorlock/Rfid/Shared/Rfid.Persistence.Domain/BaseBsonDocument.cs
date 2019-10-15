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
            AddedAtUtc = DateTime.UtcNow;
            BsonObjectId = ObjectId.GenerateNewId();
        }


        /// <summary>
        /// The <see cref="ObjectId"/> of the document.
        /// </summary>
        [BsonId]
        [BsonElement("_id")]
        public ObjectId BsonObjectId { get; set; }


        /// <summary>
        /// The <see cref="BsonDateTime"/> of when the <see cref="Document"/> was added to the collection.
        /// </summary>
        [BsonElement("AddedAtUtc")]
        public BsonDateTime AddedAtUtc { get; }
    }
}
