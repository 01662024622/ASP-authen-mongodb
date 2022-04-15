using System;

namespace WebApplication2.Entity.Conpany
{
    public class CustomerConfig
    {
        public string TcpDomain { get; set; }
        public string HttpDomain { get; set; }
        public string WebDomain { get; set; }
        public string TcpDomainBk { get; set; }
        public string HttpDomainBk { get; set; }
        public string WebDomainBk { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondColor { get; set; }
        public string AndroidPackage { get; set; }
        public string IOSPackage { get; set; }
        public Int32 TcpPort { get; set; }
        public Int32 TcpPortBk { get; set; }
    }
}