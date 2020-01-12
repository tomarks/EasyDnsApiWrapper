# EasyDnsApiWrapper
.Net Core Wrapper Library, for Name.Com API

# API Support
Currently this is only a wrapper for Name.com API

# Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create the service helper
        var svc = EasyDns.NameDotComApiWrapper(" {namedotcom_account_username} ", " {namedotcom_api_key} ");

        // Loop over existing domain records for given domain name
        foreach (var record in svc.GetDomainRecords(" {your_domain_name} "))
        {
            Console.Write($"Update Domain Record {record.DomainName} from {record.Answer} ");
            record.Answer = svc.MyPublicIP;
            
            // Updates record and returns result from API PUT request
            var resultRecord = svc.UpdateDomainRecord(record);
            Console.WriteLine($"to {resultRecord.Answer}");
        }

        Console.ReadKey();
    }
}
```
