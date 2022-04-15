using System;
using MongoDB.Driver;

namespace WebApplication2.Vendors.MongoConnection.enforcement
{
    public class ConnectionMongoDb : IConnectionMongoDb
    {
        private readonly IDatabaseSetting _databaseSetting;
        private static IMongoDatabase _connection;

        public ConnectionMongoDb(IDatabaseSetting databaseSetting)
        {
            _databaseSetting = databaseSetting;
        }

        public IMongoDatabase GetConnectionDb()
        {
            if (_connection == null)
            {
                _connection = CreateConnection();
                return _connection;
            }

            return _connection;
        }

        private IMongoDatabase CreateConnection()
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            return client.GetDatabase(_databaseSetting.DatabaseName);
        }
    }
}