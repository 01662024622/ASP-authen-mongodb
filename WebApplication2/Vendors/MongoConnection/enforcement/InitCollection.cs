namespace WebApplication2.Vendors.MongoConnection.enforcement
{
    public class InitCollection
    {
        public static void Init()
        {
            GenerateCollection generateCollection = new GenerateCollection(new ConnectionMongoDb(new DatabaseSetting()));
            generateCollection.GetTypesInNamespace();
        }
    }
}