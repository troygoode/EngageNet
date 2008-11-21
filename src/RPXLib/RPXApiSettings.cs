using System.Net;
using RPXLib.Interfaces;

namespace RPXLib
{
    public class RPXApiSettings : IRPXApiSettings
    {
        private readonly string apiKey;
        private readonly string apiBaseUrl;
        private readonly IWebProxy webProxy;

        public RPXApiSettings(string apiBaseUrl, string apiKey) : this(apiBaseUrl, apiKey, null)
        {
        }

        public RPXApiSettings(string apiBaseUrl, string apiKey, IWebProxy webProxy)
        {
            this.apiBaseUrl = apiBaseUrl;
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

        public string ApiBaseUrl
        {
            get { return apiBaseUrl; }
        }

        #endregion
    }
}