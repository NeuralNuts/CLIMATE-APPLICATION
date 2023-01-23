﻿namespace CLIMATE_DATA_BRAZIL.Models
{
    #region MongoDB Settings Model
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string Database { get; set; } = null!;
        public string Collection { get; set; } = null!;
    }
    #endregion
}