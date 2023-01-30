#region Imports
using CLIMATE_DATA_BRAZIL.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
#endregion

namespace CLIMATE_DATA_BRAZIL.Services
{
    public class MongoDBServices
    {
        #region Setting The IMongoCollection To Weather
        private readonly IMongoCollection<SensorDataModel> _weatherCollection;
        #endregion

        #region ConnectionURI, Database & Collection - Variables
        public MongoDBServices(IOptions<MongoDBSettings> mongodbSettings) 
        {
            MongoClient client = new MongoClient(mongodbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongodbSettings.Value.Database);
            _weatherCollection = database.GetCollection<SensorDataModel>(mongodbSettings.Value.Collection);
        }
        #endregion

        #region Get Weather Aysnc
        public async Task<List<SensorDataModel>> GetWeatherAsync()
        {
            return await _weatherCollection.Find(new BsonDocument()).Limit(10).ToListAsync();
        }
        #endregion

        #region Create Weather Async
        public async Task CreateWeatherAsync(SensorDataModel weather)
        {
            await _weatherCollection.InsertOneAsync(weather);
            return;
        }
        #endregion
    }
}
