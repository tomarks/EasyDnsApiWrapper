using EasyDnsLibrary.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace EasyDnsLibrary.Services.NameDotCom
{
    public partial class NameDotComDnsService: DnsServiceBase, IDnsService<NameDotComDomainRecord>
    {
        private string UserName { get; set; }
        private string ApiToken { get; set; }
        private readonly string ApiBaseUrl = "https://api.name.com/v4";
        private string EncodedBasicAuth { get; set; }

        #region CONSTRUCTOR
        public NameDotComDnsService(string userName, string apiToken) : base()
        {
            UserName = userName;
            ApiToken = apiToken;
            EncodedBasicAuth = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(UserName + ":" + ApiToken));
        }
        #endregion

        #region PUBLIC METHODS
        public List<NameDotComDomainRecord> GetDomainRecords(string domainName)
        {
            HttpWebRequest request = CreateApiWebRequest($"domains/{domainName}/records", HttpMethod.Get);

            // Format Response
            var jsonString = GetResponse(request);
            var data = JObject.Parse(jsonString)["records"].ToArray();
            return data.Select(item => item.ToObject<NameDotComDomainRecord>()).ToList();
        }

        public NameDotComDomainRecord CreateDomainRecord(string domainName, string host, string type = "A", string answer = "", int ttl = 300)
        {
            // Validate Input
            // Create Model
            var NewDomainRecord = new NameDotComDomainRecord()
            {
                DomainName = domainName,
                Host = host,
                Type = type,
                Answer = answer,
                TimeToLive = ttl
            };

            var request = CreateApiWebRequest($"domains/{domainName}/records", HttpMethod.Post, NewDomainRecord.AsJson());

            return NewDomainRecord;
        }

        public NameDotComDomainRecord UpdateDomainRecord(NameDotComDomainRecord domainRecord)
        {
            // Validate Input
            if (domainRecord.DomainName.IsEmpty())
                throw new Exception("DomainName cannot be empty;");

            HttpWebRequest request = CreateApiWebRequest($"domains/{domainRecord.DomainName}/records/{domainRecord.Id}", HttpMethod.Put, JsonConvert.SerializeObject(domainRecord));
         
            // Format Response
            var jsonString = GetResponse(request);
            var data = JObject.Parse(jsonString);
            return data.ToObject<NameDotComDomainRecord>();
        }
        #endregion

        #region INTERNAL METHODS
        private HttpWebRequest CreateApiWebRequest(string endpoint, HttpMethod method, string data = null)
        {
            string url = string.Join("/", ApiBaseUrl.TrimEnd('/'), endpoint.TrimStart('/'));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method.ToString();
            
            if(method == HttpMethod.Get)
                request.AutomaticDecompression = DecompressionMethods.GZip;

            request.Headers.Add("Authorization", EncodedBasicAuth);

            if (!data.IsEmpty())
            {
                using Stream requestStream = request.GetRequestStream();
                requestStream.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data)));
            }

            return request;
        }

        private string GetResponse(HttpWebRequest request)
        {
            string responseString;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return responseString;
        }
        #endregion
    }
}
