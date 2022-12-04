using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Internet_Services_PG.Models;

namespace Internet_Services_PG.Services
{
    public class PressureService
    {
        private readonly IMongoCollection<Pressure> _pressures;

        public PressureService(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _pressures = database.GetCollection<Pressure>(settings.PressureCollectionName);
        }
        
        public List<Pressure> Get() =>
            _pressures.Find(book => true).ToList();

        public Pressure Get(string id) =>
            _pressures.Find<Pressure>(book => book.Id == id).FirstOrDefault();

        public Pressure Create(Pressure book)
        {
            _pressures.InsertOne(book);
            return book;
        }
    }
}