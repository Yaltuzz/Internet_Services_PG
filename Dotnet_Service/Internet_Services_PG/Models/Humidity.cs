using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Internet_Services_PG.Models
{
    public class Humidity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")] 
        [JsonInclude]
        public string InstanceName { get; set; } = null!;
        [JsonInclude]
        public decimal HumidityValue { get; set; }
        [JsonInclude]
        public string Date { get; set; }
    }
}