using System.Collections.Generic;
using Internet_Services_PG.Models;
using MongoDB.Driver;

namespace Internet_Services_PG.Services
{
    public class HumidityService
    {
        private readonly IMongoCollection<Humidity> _humidityList;

        public HumidityService(IDatabaseSetting settings)
        {
            var client = new MongoClient("mongodb://root:example@mongo:27017");
            var database = client.GetDatabase("AtomicSensors");
            _humidityList = database.GetCollection<Humidity>("HumiditySensors");
        }
        
        public List<Humidity> Get() =>
            _humidityList.Find(humidity => true).ToList();

        public Humidity Get(string id) =>
            _humidityList.Find<Humidity>(humidity => humidity.Id == id).FirstOrDefault();

        public Humidity Create(Humidity humidity)
        {
            _humidityList.InsertOne(humidity);
            return humidity;
        }
    }
}