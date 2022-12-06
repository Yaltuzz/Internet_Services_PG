using System.Collections.Generic;
using Internet_Services_PG.Models;
using MongoDB.Driver;

namespace Internet_Services_PG.Services
{
    public class TemperatureService
    {
        private readonly IMongoCollection<Temperature> _temperatures;

        public TemperatureService(IDatabaseSetting settings)
        {
            var client = new MongoClient("mongodb://root:example@mongo:27017");
            var database = client.GetDatabase("AtomicSensors");
            _temperatures = database.GetCollection<Temperature>("TemperatureSensors");
        }
        
        public List<Temperature> Get() =>
            _temperatures.Find(temperature => true).ToList();

        public Temperature Get(string id) =>
            _temperatures.Find<Temperature>(temperature => temperature.Id == id).FirstOrDefault();

        public Temperature Create(Temperature temperature)
        {
            _temperatures.InsertOne(temperature);
            return temperature;
        }
    }
}