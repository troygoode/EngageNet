using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace EngageNet.Api
{
	public class ApiWrapper : IApiWrapper
	{
		private readonly string _apiKey;
		private readonly string _baseUrl;
		private readonly IWebProxy _webProxy;

		public ApiWrapper(IEngageNetSettings settings)
		{
			var url = settings.ApiBaseUrl;
			if (!url.EndsWith(@"/"))
				url = url + "/";

			_baseUrl = url;
			_apiKey = settings.ApiKey;
			_webProxy = settings.WebProxy;
		}

		public string BaseUrl
		{
			get { return _baseUrl; }
		}

		public string ApiKey
		{
			get { return _apiKey; }
		}

		#region IApiWrapper Members

		public XElement Call(string methodName, IDictionary<string, string> queryData)
		{
			var postData = GeneratePostData(queryData);
			var requestUri = new Uri(BaseUrl + methodName + "?" + postData);

			var request = BuildApiWebRequest(requestUri);

			using (var response = (HttpWebResponse) request.GetResponse())
			using (var dataStream = response.GetResponseStream())
			using (var responseReader = new StreamReader(dataStream))
			{
				return ApiResponseParser.Parse(responseReader);
			}
		}

		#endregion

		private HttpWebRequest BuildApiWebRequest(Uri requestUri)
		{
			var apiWebRequest = (HttpWebRequest) WebRequest.Create(requestUri);

			if (_webProxy != null)
				apiWebRequest.Proxy = _webProxy;

			return apiWebRequest;
		}

		private string GeneratePostData(IDictionary<string, string> partialQuery)
		{
			IDictionary<string, string> query = new Dictionary<string, string>(partialQuery)
			                                    	{
			                                    		{"format", "xml"},
			                                    		{"apiKey", ApiKey}
			                                    	};

			var sb = new StringBuilder();
			foreach (var e in query)
			{
				if (sb.Length > 0)
				{
					sb.Append('&');
				}

				sb.Append(HttpUtility.UrlEncode(e.Key, Encoding.UTF8));
				sb.Append('=');
				sb.Append(HttpUtility.UrlEncode(e.Value, Encoding.UTF8));
			}
			return sb.ToString();
		}
	}
}