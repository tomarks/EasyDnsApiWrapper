using System.Collections.Generic;

namespace EasyDnsLibrary.Interfaces
{
    public interface IDnsService<T> where T : IDomainRecord
    {
        public List<T> GetDomainRecords(string domainName);
        public T UpdateDomainRecord(T domainRecord);
        public T CreateDomainRecord(string domainName, string host, string type = "A", string answer = "", int ttl = 300);
    }
}
