using System;
using System.Linq;
using System.Reflection;
using WebApplication2.Vendors.CollectionAnotation;

namespace WebApplication2.Vendors.MongoConnection.enforcement
{
    public class GenerateCollection : IGenerateCollection
    {
        private readonly IConnectionMongoDb _connection;

        public GenerateCollection(IConnectionMongoDb connection)
        {
            _connection = connection;
        }
        
        public static String GetCollectionName(Type type)
        {
            if (type.GetCustomAttributes(typeof(TevCollectionNameAttribute)).FirstOrDefault() is
                TevCollectionNameAttribute collectionName)
            {
                return collectionName.Name;
            }

            return type.Name;
        }

        public void GetTypesInNamespace()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttribute<TevEntityAttribute>() != null)
                {
                    var collection = GetCollectionName(type);
                    _connection.GetConnectionDb().CreateCollection(collection);
                }
            }
        }
    }
}