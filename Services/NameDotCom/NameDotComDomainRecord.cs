using AutoMapper;
using EasyDnsLibrary.Interfaces;
using Newtonsoft.Json;

namespace EasyDnsLibrary.Services.NameDotCom
{
    public class NameDotComDomainRecord : IDomainRecord
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("domainName")]
        public string DomainName { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("fqdn")]
        public string FQDN { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; set; }

        public string AsJson() => JsonConvert.SerializeObject(this);

        //public IDomainRecord ToIDomainRecord()
        //{
        //    var mapper = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<IDomainRecord, NameDotComDomainRecord>()
        //        .ForAllOtherMembers(x => x.Ignore());
        //    }).CreateMapper();

        //    return mapper.Map<NameDotComDomainRecord, IDomainRecord>(this);
        //}
    }
}
