﻿namespace WebApplication2.Vendors.MongoConnection.enforcement
{
    public class DatabaseSetting:IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}