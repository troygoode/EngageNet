using System.Web;
using System.Web.Mvc;

namespace EngageNet.Mvc.Html
{
	public class EngageUrlBuilder
	{
		private readonly UrlHelper _urlHelper;

		public EngageUrlBuilder(UrlHelper urlHelper)
		{
			_urlHelper = urlHelper;
		}

		private const string EngageOverlayUrlFormat = "https://{0}/openid/v2/signin?token_url={1}";
		private const string EngageEmbedUrlFormat = "https://{0}/openid/embed?token_url={1}";

		public string TokenUrl(string action, string controller)
		{
			return string.Format(
				"{0}://{1}{2}",
				_urlHelper.RequestContext.HttpContext.Request.ServerVariables["HTTPS"] == "ON" ? "https" : "http",
				_urlHelper.RequestContext.HttpContext.Request.ServerVariables["HTTP_HOST"],
				VirtualPathUtility.ToAbsolute(_urlHelper.Action(action, controller))
				);
		}

		public string OverlayUrl(string action, string controller)
		{
			var tokenUrl = TokenUrl(action, controller);
			return string.Format(EngageOverlayUrlFormat, EngageProvider.ApplicationDomain, _urlHelper.Encode(tokenUrl));
		}

		public string EmbedUrl(string action, string controller)
		{
			var tokenUrl = TokenUrl(action, controller);
			return string.Format(EngageEmbedUrlFormat, EngageProvider.ApplicationDomain, _urlHelper.Encode(tokenUrl));
		}
	}
}