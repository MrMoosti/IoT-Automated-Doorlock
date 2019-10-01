using MongoDB.Bson.Serialization.Attributes;
using Rfid.Persistence.Domain.Enums;

namespace Rfid.Persistence.Domain.Collections
{

    public class Cpu : BaseBsonDocument
    {

        /// <summary>
        /// The <see cref="DoorStatus"/> of this <see cref="Door"/>
        /// </summary>
        [BsonElement("Temprature")]
        public double Temprature { get; set; }

        [BsonElement("Temprature")]
        public CpuState State { get; set;}
    }
}
