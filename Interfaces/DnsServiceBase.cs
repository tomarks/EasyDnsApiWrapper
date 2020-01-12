using System;
using System.Net;
using System.Text.RegularExpressions;

namespace EasyDnsLibrary.Interfaces
{
    public class DnsServiceBase
    {
        public string MyPublicIP { get; private set; }

        public DnsServiceBase()
        {
            FetchMyPublicIP();
        }

        private void FetchMyPublicIP()
        {
            string html = string.Empty;
            try
            {
                html = new WebClient().DownloadString(new Uri("http://checkip.dyndns.org"));
                if (html.Length == 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                html = new WebClient().DownloadString(new Uri("https://www.name.com/ip"));
            }

            var regexIpFilter = new Regex(@"\d+\.\d+.\d+.\d+");
            Match match = regexIpFilter.Match(html);
            MyPublicIP = match.Value;
        }
    }
}
