using System.Collections.Generic;
using Internet_Services_PG.Models;
using MongoDB.Driver;

namespace Internet_Services_PG.Services
{
    public class RadiationService
    {
        private readonly IMongoCollection<Radiation> _radiations;

        public RadiationService(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _radiations = database.GetCollection<Radiation>(settings.RadiationCollectionName);
        }
        
        public List<Radiation> Get() =>
            _radiations.Find(radiation => true).ToList();

        public Radiation Get(string id) =>
            _radiations.Find<Radiation>(radiation => radiation.Id == id).FirstOrDefault();

        public Radiation Create(Radiation radiation)
        {
            _radiations.InsertOne(radiation);
            return radiation;
        }
    }
}