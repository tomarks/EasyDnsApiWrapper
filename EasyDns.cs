using EasyDnsLibrary.Services;
using EasyDnsLibrary.Services.NameDotCom;

namespace EasyDnsLibrary
{
    public static class EasyDns
    {
        /// <summary>
        /// Configures a Name.com Dns API Service.
        /// </summary>
        /// <param name="userName">UserName of your name.com account.</param>
        /// <param name="apiToken">Api Token you generated.</param>
        public static NameDotComDnsService NameDotComApiWrapper(string userName, string apiToken) => new NameDotComDnsService(userName, apiToken);
    }
}
