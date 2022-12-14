namespace Internet_Services_PG.Models
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PressureCollectionName { get; set; } = null!;
        
        public string TemperatureCollectionName { get; set; } = null!;

        public string RadiationCollectionName { get; set; } = null!;
        
        public string HumidityCollectionName { get; set; } = null!;


    }
    
    public interface IDatabaseSetting
    {
        string PressureCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string TemperatureCollectionName { get; set; }
        string RadiationCollectionName { get; set; }
        string HumidityCollectionName { get; set; }
    }
}