using Newtonsoft.Json;

namespace EasyDnsLibrary.Interfaces
{
    public interface IDomainRecord
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public string Host { get; set; }
        public string FQDN { get; set; }
        public string Type { get; set; }
        public string Answer { get; set; }
        public int TimeToLive { get; set; }
    }
}
