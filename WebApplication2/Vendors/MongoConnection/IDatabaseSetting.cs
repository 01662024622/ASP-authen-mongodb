namespace WebApplication2.Vendors.MongoConnection
{
    public interface IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        
    }
}