using System;

namespace WebApplication2.Entity.Conpany
{
    public class OperatorConfig
    {
        public string Account { get; set; }
        public string ApiService { get; set; }
        public string ApiServiceBk { get; set; }
        public string OnlineService { get; set; }
        public string OnlineServiceBk { get; set; }
        public string ServerService { get; set; }
        public string ServerServiceBk { get; set; }
        public string TcpDomain { get; set; }
        public string TcpDomainBk { get; set; }
        public string XNCode { get; set; }
        public Int32 CompanyId { get; set; }
        public Int32 TcpPort { get; set; }
        public Int32 TcpPortBk { get; set; }
    }
}