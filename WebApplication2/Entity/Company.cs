using System;
using System.Collections.Generic;
using WebApplication2.Entity.Conpany;
using WebApplication2.Vendors.Entity;

namespace WebApplication2.Entity
{
    public class Company:EntityBase
    {
        public string CompanyName { get; set; }
        public DriverConfig DriverConfig { get; set; }
        public GroupServer GroupServer { get; set; }
        public Boolean UseBackupServer { get; set; }
        public Boolean EnableAlert { get; set; }
        public Int32 TotalFail { get; set; }
        public CustomerConfig CustomerConfig { get; set; }
        public List<OperatorConfig> OperatorConfigs{ get; set; }
    }
}