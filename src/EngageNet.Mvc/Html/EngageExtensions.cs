using System.Web.Mvc;

namespace EngageNet.Mvc.Html
{
	public static class EngageExtensions
	{
		public static EngageUrlBuilder Engage(this UrlHelper urlHelper)
		{
			return new EngageUrlBuilder(urlHelper);
		}

		public static EngageWidgetBuilder Engage(this HtmlHelper htmlHelper)
		{
			return new EngageWidgetBuilder(htmlHelper);
		}
	}
}