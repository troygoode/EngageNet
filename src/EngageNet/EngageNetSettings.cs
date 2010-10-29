using System.Net;

namespace EngageNet
{
	public class EngageNetSettings : IEngageNetSettings
	{
		private readonly string _apiBaseUrl;
		private readonly string _apiKey;
		private readonly IWebProxy _webProxy;

		public EngageNetSettings(string apiKey)
			: this("https://rpxnow.com/api/v2/", apiKey, null)
		{
		}

		public EngageNetSettings(string apiBaseUrl, string apiKey, IWebProxy webProxy)
		{
			_apiBaseUrl = apiBaseUrl;
			_apiKey = apiKey;
			_webProxy = webProxy;
		}

		#region IEngageNetSettings Members

		public IWebProxy WebProxy
		{
			get { return _webProxy; }
		}

		public string ApiKey
		{
			get { return _apiKey; }
		}

		public string ApiBaseUrl
		{
			get { return _apiBaseUrl; }
		}

		#endregion
	}
}