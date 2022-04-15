using MongoDB.Driver;

namespace WebApplication2.Vendors.MongoConnection
{
    public interface IConnectionMongoDb
    {
        public IMongoDatabase GetConnectionDb();
    }
}