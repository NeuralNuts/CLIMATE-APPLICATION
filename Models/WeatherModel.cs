#region Imports
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
#endregion

namespace CLIMATE_DATA_BRAZIL.Models
{
    #region Weather Model
    public class WeatherModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("time")]
        public string Time { get; set; } = null!;

        [BsonElement("temperature")]
        public string Temperature { get; set; } = null!;

        [BsonElement("dew_point")]
        public string DewPoint { get; set; } = null!;

        [BsonElement("humidity")]
        public string Humidity { get; set; } = null!;

        [BsonElement("wind")]
        public string Wind { get; set; } = null!;

        [BsonElement("wind_speed")]
        public string WindSpeed { get; set; } = null!;

        [BsonElement("wind_gust")]
        public string WindGust { get; set; } = null!;

        [BsonElement("pressure")]
        public string Pressure { get; set; } = null!;

        [BsonElement("precip")]
        public string Precip { get; set; } = null!;

        [BsonElement("condition")]
        public string Condition { get; set; } = null!;
    }
    #endregion
}