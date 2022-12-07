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
            var client = new MongoClient("mongodb://root:student@actina15.maas:27017");
            var database = client.GetDatabase("si_176446");
            _pressures = database.GetCollection<Pressure>("PressureSensors");
        }
        
        public void AddSensor(Pressure pressure)
        {
            _pressures.InsertOne(pressure);
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