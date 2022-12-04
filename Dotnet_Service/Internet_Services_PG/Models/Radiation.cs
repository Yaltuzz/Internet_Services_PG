using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Internet_Services_PG.Models
{
    public class Radiation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")] 
        public string InstanceName { get; set; } = null!;
        public decimal RadiationValue { get; set; }
    }
}