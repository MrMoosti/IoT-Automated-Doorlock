using MongoDB.Bson.Serialization.Attributes;
using Rfid.Persistence.Domain.Enums;

namespace Rfid.Persistence.Domain.Collections
{

    public class Cpu : BaseBsonDocument
    {
        [BsonElement("Temprature")]
        public double Temprature { get; set; }

        [BsonElement("State")]
        public CpuState State { get; set;}
    }
}
