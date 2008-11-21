using System.Net;
using RPXLib.Interfaces;

namespace RPXLib
{
    public class RPXApiSettings : IRPXApiSettings
    {
        private readonly string apiKey;
        private readonly string baseUrl;
        private readonly IWebProxy webProxy;

        public RPXApiSettings(string baseUrl, string apiKey) : this(baseUrl, apiKey, null)
        {
        }

        public RPXApiSettings(string baseUrl, string apiKey, IWebProxy webProxy)
        {
            this.baseUrl = baseUrl;
            this.apiKey = apiKey;
            this.webProxy = webProxy;
        }

        #region IRPXApiSettings Members

        public IWebProxy WebProxy
        {
            get { return webProxy; }
        }

        public string ApiKey
        {
            get { return apiKey; }
        }

        public string BaseUrl
        {
            get { return baseUrl; }
        }

        #endregion
    }
}