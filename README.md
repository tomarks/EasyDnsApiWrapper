# EasyDnsApiWrapper
.Net Core Wrapper Library, for Name.Com API

# Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        var svc = EasyDns.NameDotComApiWrapper(" {namedotcom_account_username} ", " {namedotcom_api_key} ");

        foreach (var record in svc.GetDomainRecords(" {your_domain_name} "))
        {
            Console.Write($"Update Domain Record {record.DomainName} from {record.Answer} ");
            record.Answer = svc.MyPublicIP;
            var resultRecord = svc.UpdateDomainRecord(record);
            Console.WriteLine($"to {resultRecord.Answer}");
        }

        Console.ReadKey();
    }
}
```
